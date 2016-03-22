# SimFrost (\#117)
This was one of the Perl Quiz of the Week problems a couple of years ago. It's also my favorite computer simulation.

The goal is to create a simulation of frost.

Here are the rules of the simulation.

First, create a two-dimensional grid to hold our simulation. The width and height must be even numbers. The top of this grid wraps (or connects) to the bottom and the left and right sides also touch, so technically we are representing a torus here.

Each cell in the grid can hold one of three things: vacuum, vapor, or ice. To begin with, place a single ice particle in the center of the grid and fill the remaining space with some random mix of vacuum and vapor. You will probably want to leave yourself a way to easily adjust the starting vapor percentage as you begin to play with the simulation.

Display the starting grid for the user, then begin a cycle of "ticks" that change the current state of the grid. Redraw the grid after each tick, so the user can see the changes. The simulation continues until there are no more vapor particles. At that time your program should exit.

Each tick changes the grid as follows. First, divide the board into "neighborhoods." A neighborhood is always a square of four cells. Given that, on the first tick we would divide a six by four grid as:

```
+--+--+--+
|  |  |  |
|  |  |  |
+--+--+--+
|  |  |  |
|  |  |  |
+--+--+--+
```
However, even numbered ticks divide the board with an offset of one. In other words, the neighborhoods will be as follows in the second round:
```
 |  |  |
-+--+--+-
 |  |  |
 |  |  |
-+--+--+-
 |  |  |
```
Remember that the grid wraps in all directions, so there are still just six neighborhoods here. Later ticks just alternate these two styles of dividing the grid.

In each neighborhood, apply one of the following two changes:

1.  If any cell in the neighborhood contains ice, all vapor particles in the
    neighborhood turn to ice.
2.  Otherwise, rotate the contents of the neighborhood 90 degrees clockwise
    or counter-clockwise (50% random chance for either).

For example (using " " for vacuum, "." for vapor, and "\*" for ice), the first rule changes:
```
+--+
| .|
|* |
+--+
```
into:
```
+--+
| *|
|* |
+--+
```
The second rule changes:
```
+--+
|..|
|  |
+--+
```
into:
```
+--+      +--+
|. |  or  | .|  50% chance
|. |      | .|
+--+      +--+
```
Time is discrete in these ticks, so given some grid state at tick T all neighborhood changes appear simultaneously in tick T + 1.

Again, use whatever output you are comfortable with, from ASCII art in the terminal to pretty graphics.

## Quiz Summary

Isn't this one a fun problem? Three cheers to Mark Jason Dominus for introducing it to me.

The solutions were fantastic as well. In particular, people found many interesting ways to render the output: using some Unixisms in the terminal, using curses, rendering trivial image formats like PPM and XPM, building images programmatically with RMagick, and even 3D rendering with OpenGL. All of those were very cool.

I'm going to show my own code below, but I will take a few diversions as we go. Here's the start of my simulator class:

``` ruby
    #!/usr/bin/env ruby -w

    class SimFrost
      def initialize(width, height, vapor)
        @ticks = 0
        @grid  = Array.new(height) do
          Array.new(width) { rand(100) < vapor ? "." : " " }
        end
        @grid[height / 2][width / 2] = "*"
      end

      attr_reader :ticks

      def width
        @grid.first.size
      end

      def height
        @grid.size
      end

      # ...
```
This setup code creates the grid object, filled with the particles described in the quiz using the quiz example notation. Several other solvers used Symbols or constants for these element which reads a lot better.

My grid is just Arrays of columns inside an Array of rows. This is called "row major" order. It's a little backwards to the way we normally think, because you index with a Y coordinate and then the X, but that's easy enough to fix with a helper method. It's also great for showing results, because you can process them row by row.

The other three methods are just accessors for attributes of the simulation.

One interesting point of discussion raised on the mailing list by Christoffer Lernö was that populating the grid as I do above, by testing a percentage for every cell, doesn't necessarily fill the grid with that exact percent of elements. The smaller the grid, the more likely you are to be off. For example:

```ruby
    >> percent = 30
    => 30
    >> grid = Array.new(100) { rand(100) < 30 ? "." : " " }
    => [" ", ".", ".", " ", " ", " ", ..., " "]
    >> grid.grep(/\./).size
    => 37
```
Notice how the actual percentage is off from my requested percentage by seven percent. This is less of an issue the bigger the grid gets and small grids don't tend to be too interesting anyway, but there will usually be some level of error with this approach.

To solve this, you really need to calculate the percentage against the full grid size and ensure that you fill exactly that many cells. Christoffer's code for that was:

```ruby
    require 'enumerator'

    percentage = 30
    width      = 30
    height     = 20
    vapour     = width * height * percentage / 100
    vacuum     = width * height - vapour
    grid       = []

    (Array.new(vacuum, ' ') + Array.new(vapour, '.')).
        sort_by { rand }.
        each_slice(width) { |s| grid << s }
```
Laziness won out though and most of us used the trivial cell by cell fill strategy.

Getting back to my code, here are two more methods on the simulator:

```ruby
      # ...

      def complete?
        not @grid.flatten.include? "."
      end

      def to_s
        @grid.map { |row| row.join }.join("\n")
      end

      # ...
```
These are pretty easy. First, complete?() just tells us if we are done by checking for any remaining vapor particles. The other method, to_s(), is just a nested join() on the grid object used to output results.

Now we're ready for the heart of the simulation:

```ruby
      # ...

      def tick
        (tick_start...height).step(2) do |y|
          (tick_start...width).step(2) do |x|
            cells = [ [x,             y            ],
                      [wrap_x(x + 1), y            ],
                      [wrap_x(x + 1), wrap_y(y + 1)],
                      [x,             wrap_y(y + 1)] ]
            if cells.any? { |xy| cell(xy) == "*" }
              cells.select { |xy| cell(xy) == "." }.
                    each { |xy| cell(xy, "*") }
            else
              rotated = cells.dup
              if rand(2).zero?
                rotated.push(rotated.shift)
              else
                rotated.unshift(rotated.pop)
              end
              new_cells = rotated.map { |xy| cell(xy) }
              cells.zip(new_cells) { |xy, value| cell(xy, value) }
            end
          end
        end
        @ticks += 1
      end

      private

      def tick_start; (@ticks % 2).zero? ? 0 : 1 end

      def wrap_x(x) x % width  end
      def wrap_y(y) y % height end

      def cell(xy, value = nil)
        if value
          @grid[xy.last][xy.first] = value
        else
          @grid[xy.last][xy.first]
        end
      end
    end
    # ...
```

The tick() method is where the action is. It walks the grid neighborhood by neighborhood making changes. Note that cells are managed as just two element Arrays and I use the human-friendly X-before-Y notation. I also build the neighborhood by putting the cells in clockwise order. This means a rotation is just a shift() and push(), or pop() and unshift() to go the other way.

Cell access is all handled through the cell() helper method, which switches the order for row major access. Christoffer Lernö had an interesting approach to this cell access problem where he defined a handful of methods with some metaprogramming:

```ruby
    class Neighbourhood

      2.times do |y|
        2.times do |x|
          class_eval %Q{
            def xy#{x}#{y}; @grid[@x + #{x}, @y + #{y}]; end
            def xy#{x}#{y}=(v); @grid[@x + #{x}, @y + #{y}] = v; end
          }
        end
      end

      # ...
```
This allowed him to define rotations as:

```ruby
      # ...

      def ccw90
        self.xy00, self.xy10, self.xy01, self.xy11 = xy10, xy11, xy00, xy01
      end

      def cw90
        self.xy00, self.xy10, self.xy01, self.xy11 = xy01, xy00, xy11, xy10
      end

      # ...
```
Getting back to my code, I also have wrappers for X and Y coordinates so I can properly handle the grid edges with modulo arithmetic. This code only ever runs off the right and bottom edges of the grid and only by one cell, so we don't need to worry about negative numbers.

Finally, tick_start() toggles the neighborhood offset for me, though Dave Burt did it with some cool bitwise XOR operations that looked like this:

```ruby
    >> offset = 0
    => 0
    >> offset ^= 1
    => 1
    >> offset ^= 1
    => 0
    >> offset ^= 1
    => 1
```
Now that we have a simulator, we're ready for some display code. The first display model I built was based on the Unix terminal because it was so easy to do:

```ruby
    # ...

    class UnixTerminalDisplay
      BLUE     = "\e[34m"
      WHITE    = "\e[37m"
      ON_BLACK = "\e[40m"
      CLEAR    = "\e[0m"

      def initialize(simulator)
        @simulator = simulator
      end

      def clear
        @clear ||= `clear`
      end

      def display
        print clear
        puts @simulator.to_s.gsub(/\.+/, "#{BLUE  + ON_BLACK}\\&#{CLEAR}").
                             gsub(/\*+/, "#{WHITE + ON_BLACK}\\&#{CLEAR}").
                             gsub(/ +/,  "#{        ON_BLACK}\\&#{CLEAR}")
      end
    end

    # ...
```
Here we just wrap a simulator with some search and replace logic. The regexen are used to wrap the icons in terminal escape codes to color them. The code also shells out to clear, or uses the cached result, to erase the terminal before each round of drawing.

While that's easy to code, it's not portable or flashy. Simulations look so much better in graphical representations and as I mentioned before, solvers produced those in a variety of ways.

My own solution to the graphics problem is another trick I learned from Mark Jason Dominus. Believe it or not, there are a few super trivial image formats that you can hand roll in no time. It pays to learn one of them, for situations like this, when you just need some quick and dirty image output. You can always use a converter to get them into more popular image formats. That's exactly how I built the quiz movie.

There are a few versions of the PPM image format, but the one I used goes by the following rules:

1.  Start the image file with P6 on its own line.
2.  The second line is the width in pixels, followed by the height in
    pixels, followed by the color range (just use 255 for this) as a
    space delimited list of integers.  For example, a 640 by 480 image
    has a second line of: 640 480 255.
3.  From that point on, the rest of data is binary.  Each pixel is
    represented by three characters which represent the amount of red,
    green, and blue coloring in that pixel.  The numeric byte value of
    the character is the amount for the color it represents.

Watch how easy that is to code up:

```ruby
    # ...

    class PPMImageDisplay
      BLUE  = [0,   0,   255].pack("C*")
      WHITE = [255, 255, 255].pack("C*")
      BLACK = [0,   0,   0  ].pack("C*")

      def initialize(simulator, directory)
        @simulator = simulator
        @directory = directory

        Dir.mkdir directory unless File.exist? directory
      end

      def display
        File.open(file_name, "w") do |image|
          image.puts "P6"
          image.puts "#{@simulator.width} #{@simulator.height} 255"
          @simulator.to_s.each_byte do |cell|
            case cell.chr
            when "." then image.print BLUE
            when "*" then image.print WHITE
            when " " then image.print BLACK
            else          next
            end
          end
        end
      end

      private

      def file_name
        File.join(@directory, "%04d.ppm" % @simulator.ticks)
      end
    end

    # ...
```
The image implementation I just described in encapsulated in the display() method. The binary values are handled by constants at the top of the class. Note how easy it is to build PPM's RGB colors using pack(). The rest of the class just creates a directory to hold the frame images and builds file names based on the current tick count.

Finally, we come to the application code of my solution:

```ruby
    if __FILE__ == $PROGRAM_NAME
      require "optparse"

      options = { :width     => 80,
                  :height    => 22,
                  :vapor     => 30,
                  :output    => UnixTerminalDisplay,
                  :directory => "frost_images" }

      ARGV.options do |opts|
        opts.banner = "Usage:  #{File.basename($PROGRAM_NAME)} [OPTIONS]"

        opts.separator ""
        opts.separator "Specific Options:"

        opts.on( "-w", "--width EVEN_INT", Integer,
                 "Sets the width for the simulation." ) do |width|
          options[:width] = width
        end
        opts.on( "-h", "--height EVEN_INT", Integer,
                 "Sets the height for the simulation." ) do |height|
          options[:height] = height
        end
        opts.on( "-v", "--vapor PERCENT_INT", Integer,
                 "The percent of the grid filled with vapor." ) do |vapor|
          options[:vapor] = vapor
        end
        opts.on( "-t", "--terminal",
                 "Unix terminal display (default)." ) do
          options[:output] = UnixTerminalDisplay
        end
        opts.on( "-i", "--image",
                 "PPM image series display." ) do
          options[:output] = PPMImageDisplay
        end
        opts.on( "-d", "--directory DIR", String,
                 "Where to place PPM image files.  ",
                 %Q{Defaults to "frost_images".} ) do |directory|
          options[:directory] = directory
        end

        opts.separator "Common Options:"

        opts.on( "-?", "--help",
                 "Show this message." ) do
          puts opts
          exit
        end

        begin
          opts.parse!
        rescue
          puts opts
          exit
        end
      end

      simulator = SimFrost.new( options[:width],
                                options[:height],
                                options[:vapor] )
      setup     = options[:output] == PPMImageDisplay ?
                  [simulator, options[:directory]]    :
                  [simulator]
      terminal  = options[:output].new(*setup)

      terminal.display
      until simulator.complete?
        sleep 0.5 if options[:output] == UnixTerminalDisplay
        simulator.tick
        terminal.display
      end
    end
```
While that looks like a lot of code, most of it is just option parsing where I fill an options Hash. The last twelve lines are where the interesting stuff happens. A simulator is constructed and then wrapped in a display class. From there we go into the main event loop which is just sleep (terminal display only), tick(), and draw until the simulation is complete?().

My thanks to all the super cool Ruby programmers who can literally create ice with the movements of their fingers.

Ruby Quiz will now take a two week vacation so I can get out of town and have a little fun. Send me some great quiz ideas while I'm gone and we will get them into play when I return.
