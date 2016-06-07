require 'tower'

class Hanoi
  attr_reader :left_tower, :middle_tower, :right_tower

  def initialize
    @left_tower = Tower.new('Left', 3)
    @middle_tower = Tower.new('Middle', 0)
    @right_tower = Tower.new('Right', 0)
    @towers = [@left_tower, @middle_tower, @right_tower]
  end

  def can_move?(source, destination)
    disc = source.pop
    destination.can_push?(disc)
  end

  def move(source, destination)
    disc = source.pop
    destination.push(disc)
    # puts "You moved the #{disc} disc from #{source.name} to #{destination.name}"
  end

  def solve
    if @right_tower.height == 3
    # puts "Well done mate!"
    else
      @towers.each_with_index do |tower, index|
        tower.height.times do
          move(tower, @towers[index + 1]) if can_move?(tower, @towers[index + 1])
        end
      end
    end
  end
end
