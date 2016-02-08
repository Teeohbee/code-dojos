class DifficultyOptions
  attr_reader :word_length

  DIFFICULTY_WORD_LENGTH = { easy: [3,4,5], medium: [6,7,8], hard: [9,10,11]}

  def set_difficulty(difficulty_selection)
    @word_length = DIFFICULTY_WORD_LENGTH[difficulty_selection].sample


  end

end
