require_relative "word_options"

class FalloutGame
  attr_accessor :correct_answer
  attr_accessor :correct_letters
  attr_reader :game_word_list

  def initialize(word_options)
    @game_word_list = word_options.game_word_list
    @correct_answer = word_options.select_winning_word
    @correct_letters = 0
  end

  def guess(answer)
    if answer == correct_answer
      true
    else
      calculate_correct_letters(answer)
      false
    end
  end

  def calculate_correct_letters(answer)
    answer.each_char.with_index do |char, index|
      if char == correct_answer[index]
        @correct_letters += 1
      end
    end
  end

end
