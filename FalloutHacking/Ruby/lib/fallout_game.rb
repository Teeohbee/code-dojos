class FalloutGame
attr_accessor :correct_answer
attr_accessor :correct_letters

def initialize()
    @correct_answer = ""
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
