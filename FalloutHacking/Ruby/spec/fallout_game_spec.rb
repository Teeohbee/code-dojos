require 'fallout_game'

describe FalloutGame do

  before(:each) do
    word_options = double("word_options", game_word_list: ["atomic","broken","throne","hacked","locked","attach","builds","lumber","change","weapon"] )
    allow(word_options).to receive(:select_winning_word).and_return("atomic")
    @game = FalloutGame.new(word_options)
  end

  describe "guess" do

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
      @game.guess "attach"
      expect(@game.correct_letters).to eq 2
    end
  end

  describe "display" do

    it 'should display the list of game words' do
      expect(@game.game_word_list).to eql ["atomic","broken","throne","hacked","locked","attach","builds","lumber","change","weapon"]
    end

  end

end
