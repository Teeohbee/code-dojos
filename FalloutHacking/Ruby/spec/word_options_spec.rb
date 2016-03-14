require 'word_options'

describe WordOptions do

  before(:each) do
    difficulty_options = double("difficulty_options")
    @word_options = WordOptions.new(difficulty_options)
  end

  describe "parse words" do

    it 'parses a text file into an array' do
      @word_options.parse_words("lib/wordlist.txt")
      expect(@word_options.words).not_to be_empty
    end

    it 'creates a new entry for each line in the text file' do
      file = "lib/wordlist.txt"
      line_count = `wc -l "#{file}"`.strip.split(' ')[0].to_i
      @word_options.parse_words("lib/wordlist.txt")
      expect(@word_options.words.count).to eql line_count
    end
  end

  describe "select word list" do
    it 'creates the word list for the game' do
      @word_options.parse_words("lib/wordlist.txt")
      @word_options.select_words(10)
      expect(@word_options.game_word_list.count).to eql 10
    end
  end

  describe "select winning word" do
    it 'selects the winning word from the game word list' do
      @word_options.parse_words("lib/wordlist.txt")
      @word_options.select_words(10)
      expect(@word_options.game_word_list.include?(@word_options.select_winning_word)).to eql true
    end
  end

end
