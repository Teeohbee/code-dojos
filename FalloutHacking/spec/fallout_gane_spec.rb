require 'fallout_game'

describe FalloutGame do

  describe "guess" do
    it { is_expected.to respond_to(:guess).with(1).arguments }
  end

end
