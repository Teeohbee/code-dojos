require 'string_calculator_tdd'

describe StringCalculatorTDD do

  it { is_expected.to respond_to(:add).with(1).arguments }

  describe "add" do

    it "returns zero when given no numbers" do
      expect(subject.add("")).to eq 0
    end

    it "returns 1 when given the string one" do
      expect(subject.add("1")).to eq 1
    end

    it "returns 2 when given the string two" do
      expect(subject.add("2")).to eq 2
    end

    it "returns 3 when given the string one and two" do
      expect(subject.add("1,2")).to eq 3
    end

    it "returns 30 when given the string one and two" do
      expect(subject.add("3,7,9,7,4")).to eq 30
    end

  end
end
