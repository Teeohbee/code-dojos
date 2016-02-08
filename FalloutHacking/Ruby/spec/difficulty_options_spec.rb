require 'difficulty_options'

describe DifficultyOptions do

  describe 'set difficulty' do

    it { is_expected.to respond_to(:set_difficulty).with(1).arguments }

    it 'updates the word length property' do
      subject.set_difficulty('medium')
      expect(subject.word_length).to be_between(6, 8).inclusive
    end

    it 'updates the word list length property' do
      subject.set_difficulty('medium')
      expect(subject.word_list_length).to be_between(9, 12).inclusive
    end
  end
end
