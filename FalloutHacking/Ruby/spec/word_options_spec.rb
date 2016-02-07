require 'word_options'

describe WordOptions do

  describe "parse words" do
    it { is_expected.to respond_to(:parse_words).with(1).arguments }

    it 'parses a text file into an array' do
      subject.parse_words("lib/wordlist.txt")
      expect(subject.words).not_to be_empty
    end
  end

end
