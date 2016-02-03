require 'fallout_game'

describe FalloutGame do

  describe "guess" do
    it { is_expected.to respond_to(:guess).with(1).arguments }

    it 'should return true when correct answer is given' do
      subject.correct_answer = "atomic"
      expect(subject.guess("atomic")).to eq true
    end

    it 'should return false when incorrect answer is given' do
      subject.correct_answer = "atomic"
      expect(subject.guess("fallout")).to eq false
    end

    it 'should calculate correct letters when incorrect answer is given' do
      subject.correct_answer = "atomic"
      subject.guess "atoned"
      expect(subject.correct_letters).to eq 3
    end
  end

end
