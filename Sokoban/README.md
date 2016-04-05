#Sokoban

Ruby isn't the only good thing to come out of Japan. The computer game Sokoban, invented by Hiroyuki Imabayashi, was introduced by Thinking Rabbit of Takarazuka, Japan in 1982. This simple game of logic puzzles was an instant success. It won awards and spawned sequels. Over the years, Sokoban has been ported to a huge number of platforms. Fan support remains strong and many of those fans even produce new levels for the game.

This week's quiz is to implement the game of Sokoban with the interface of your choosing and any extra features you would like to have.

Sokoban (which translates to "Warehouse Man") has simple rules, which basically amount to push crates into their storage spots in the warehouse. The elements of the levels are simple: The "man", crates, walls, open floor, and storage. Different level designers use various symbols to represent these items in level data files. Here's one possible mix:

```
@         for the man
o         for crates
#         for walls
<space>   for open floor
.         for storage
```

Now because a man or a crate can also be on a storage space, we need special conditions to represent those setups:

```
*         for crate on storage
+         for man on storage
```

Using this, we can build an extremely simple level:

```
#####
#.o@#
#####
```

This level is completely surrounded by walls, as all Sokoban levels must be. Walls are, of course, impassable. In the center we have from left to right: A storage space, a crate (on open floor), and the man (also on open floor).

(The original Sokoban levels were 19 x 16, but later levels have varied in size.)

The game is played by moving the man up, down, left and right. When the man moves towards a crate, he may push it along in front of him as long as there is no wall or second crate behind the one being pushed. A level is solved when all crates are on storage spaces.

Given those rules, we can solve our level above with a single move to the left, yielding:

```
#####
#*@ #
#####
```

That simple system can lead to some surprisingly complicated mind benders!

Be warned, Sokoban is extremely addictive!
