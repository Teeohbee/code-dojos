class WordOptions
  attr_reader :words
  attr_reader :game_word_list

  def initialize(difficulty_options)
    @words = []
    @game_word_list = []
    @difficulty_options = difficulty_options
  end

  def parse_words(file_path)
    File.open(file_path).each_line do |word|
      @words << word.delete("\n")
    end
  end

  def select_words()
    shuffled_words = @words.shuffle
    @game_word_list = shuffled_words.first(@difficulty_options.word_list_length)
  end

  def select_winning_word
    @game_word_list.sample
  end

end
