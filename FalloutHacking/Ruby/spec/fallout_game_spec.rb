require 'fallout_game'

describe FalloutGame do

  describe "guess" do

    before(:each) do
      word_options = double("word options", game_word_list: ["atomic","broken","throne","hacked","locked","attach","builds","lumber","change","weapon"] )
      allow(word_options).to receive(:select_winning_word).and_return("atomic")
      @game = FalloutGame.new(word_options)
    end

    xit { is_expected.to respond_to(:guess).with(1).arguments }

    it 'should return true when correct answer is given' do
      @game.correct_answer = "atomic"
      expect(@game.guess("atomic")).to eq true
    end

    it 'should return false when incorrect answer is given' do
      @game.correct_answer = "atomic"
      expect(@game.guess("booked")).to eq false
    end

    it 'should calculate correct letters when incorrect answer is given' do
      @game.correct_answer = "atomic"
      @game.guess "atoned"
      expect(@game.correct_letters).to eq 3
    end
  end

end
