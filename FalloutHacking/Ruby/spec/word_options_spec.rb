require 'word_options'

describe WordOptions do

  describe "parse words" do
    it { is_expected.to respond_to(:parse_words).with(1).arguments }

    xit 'should return true when correct answer is given' do
      subject.correct_answer = "atomic"
      expect(subject.guess("atomic")).to eq true
    end
  end

end
