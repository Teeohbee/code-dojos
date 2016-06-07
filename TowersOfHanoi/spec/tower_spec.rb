require 'spec_helper'
require 'tower'

describe Tower do
  before(:each) do
    @tower = Tower.new("Left", 3)
  end

  describe "height" do
    it "returns the number of discs on the tower" do
      expect(@tower.height).to eql 3
    end

    it "returns the number of discs on the tower" do
      @tower = Tower.new("Left", 0)
      expect(@tower.height).to eql 0
    end
  end

  describe "pop" do
    it "takes the top disc from the tower" do
      top_disc = @tower.pop
      expect(top_disc).to eql 1
      expect(@tower.height).to eql 2
    end
  end

  describe "can_push?" do
    it "returns true when the disc can be added to the tower" do
      @tower.pop
      expect(@tower.can_push?(1)).to eql true
    end

    it "returns false when the disc cannot be added to the tower" do
      @tower.pop
      @tower.push(3)
      expect(@tower.can_push?(3)).to eql false
    end
  end

  describe "push" do
    it "adds the disc to the top of the tower" do
      @tower.pop
      @tower.push(1)
      expect(@tower.height).to eql 3
    end

    it "cannot add a larger disc on top of a smaller one" do
      @tower.pop
      @tower.push(3)
      expect(@tower.height).to eql 2
    end
  end
end
