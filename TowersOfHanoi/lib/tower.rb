class Tower
attr_reader :name

  def initialize(name, discs)
    @name = name
    @discs = [*1..discs].reverse
  end

  def height
    @discs.length
  end

  def pop
    @discs.pop
  end

  def can_push?(disc)
    top_disc = @discs[-1] || 4
    disc < top_disc
  end

  def push(disc)
    if can_push?(disc)
      @discs.push(disc)
    end
  end

end
