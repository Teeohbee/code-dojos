require 'spec_helper'
require 'hanoi'

describe Hanoi do
  before(:each) do
    @game = Hanoi.new
  end

  describe 'move' do
    it 'moves a disc from one tower to another' do
      @game.move(@game.left_tower, @game.middle_tower)
      expect(@game.left_tower.height).to eql(2)
      expect(@game.middle_tower.height).to eql(1)
    end
  end

  describe 'can_move?' do
    it 'returns true if a move can be made' do
      result = @game.can_move?(@game.left_tower, @game.middle_tower)
      expect(result).to eql(true)
    end

    it 'returns false if a move cannot be made' do
      @game.move(@game.left_tower, @game.middle_tower)
      result = @game.can_move?(@game.left_tower, @game.middle_tower)
      expect(result).to eql(false)
    end
  end
end
