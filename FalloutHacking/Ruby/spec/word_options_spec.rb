require 'word_options'

describe WordOptions do

  describe "parse words" do
    it { is_expected.to respond_to(:parse_words).with(1).arguments }

    it 'parses a text file into an array' do
      subject.parse_words("lib/wordlist.txt")
      expect(subject.words).not_to be_empty
    end

    it 'creates a new entry for each line in the text file' do
      file = "lib/wordlist.txt"
      line_count = `wc -l "#{file}"`.strip.split(' ')[0].to_i
      subject.parse_words("lib/wordlist.txt")
      expect(subject.words.count).to eql line_count
    end
  end

  describe "select word list" do
    it 'creates the word list for the game' do
      subject.parse_words("lib/wordlist.txt")
      subject.select_words(10)
      expect(subject.game_word_list.count).to eql 10
    end


  end

end
