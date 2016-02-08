class DifficultyOptions
  attr_reader :word_length
  attr_reader :word_list_length

  DIFFICULTY_WORD_LENGTH = { easy: [3,4,5], medium: [6,7,8], hard: [9,10,11]}
  DIFFICULTY_WORD_LIST_LENGTH = { easy: [5,6,7,8], medium: [9,10,11,12], hard: [13,14,1516]}

  def set_difficulty(difficulty_selection)
    @word_length = DIFFICULTY_WORD_LENGTH[difficulty_selection.to_sym].sample
    @word_list_length = DIFFICULTY_WORD_LIST_LENGTH[difficulty_selection.to_sym].sample
  end

end
