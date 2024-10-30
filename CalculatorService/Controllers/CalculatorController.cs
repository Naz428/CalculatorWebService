using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("calculator")]
public class CalculatorController : ControllerBase
{
    [HttpPost("add")]
    public IActionResult Add([FromBody] double[] numbers)
    {
        var result = numbers.Sum();
        return Ok(result);
    }

    [HttpPost("subtract")]
    public IActionResult Subtract([FromBody] double[] numbers)
    {
        if (numbers.Length == 0) return BadRequest("No numbers provided.");
        var result = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            result -= numbers[i];
        }
        return Ok(result);
    }

    [HttpPost("multiply")]
    public IActionResult Multiply([FromBody] double[] numbers)
    {
        var result = numbers.Aggregate(1.0, (acc, number) => acc * number);
        return Ok(result);
    }

    [HttpPost("divide")]
    public IActionResult Divide([FromBody] double[] numbers)
    {
        if (numbers.Length == 0) return BadRequest("No numbers provided.");
        var result = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == 0) return BadRequest("Cannot divide by zero.");
            result /= numbers[i];
        }
        return Ok(result);
    }
    [HttpPost("sqrt")]
    public IActionResult SquareRoot([FromBody] double[] numbers)
    {
        var result = numbers.Select(Math.Sqrt).ToArray();
        return Ok(result);
    }

    [HttpPost("power")]
    public IActionResult Power([FromBody] double[] numbers)
    {
        if (numbers.Length != 2) return BadRequest("Power operation requires exactly 2 numbers (base and exponent).");
        var result = Math.Pow(numbers[0], numbers[1]);
        return Ok(result);
    }
}
