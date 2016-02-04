class StringCalculatorTDD

  def add(numbers)
    if numbers == ""
      0
    else
      split_numbers = numbers.split(",")
      sum = 0
      split_numbers.each do |number|
        sum += number.to_i
      end
      sum
    end
  end

end
