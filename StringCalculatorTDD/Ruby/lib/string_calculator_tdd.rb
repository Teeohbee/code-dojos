class StringCalculatorTDD

  def add(numbers)
    if is_empty?(numbers)
      handle_empty_string
    else
      split_numbers = numbers.split(",")
      calculate_sum(split_numbers)
    end
  end

  def is_empty?(numbers)
    numbers == ""
  end

  def handle_empty_string
    0
  end

  def calculate_sum(numbers)
    sum = 0
    numbers.each do |number|
      sum += number.to_i
    end
    sum
  end

end
