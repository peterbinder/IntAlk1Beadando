using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntAlk1Beadando;

public class CalcModel : PageModel
{
    [BindProperty]
    public int Number1 { get; set; }

    [BindProperty]
    public int Number2 { get; set; }

    [BindProperty]
    public string Operation { get; set; }

    public int? Result { get; set; }
    public string? ErrorMessage { get; set; }

    public void OnPost()
    {
        ErrorMessage = null;

        if (Enum.TryParse(Operation, true, out MathOperation parsedOperation))
        {
            Result = Calculate(parsedOperation);
        }
        else
        {
            Result = null;
        }
    }
    
    private int? Calculate(MathOperation operation)
    {
        switch (operation)
        {
            case MathOperation.Add:
                return Add(Number1, Number2);
            case MathOperation.Subtract:
                return Subtract(Number1, Number2);
            case MathOperation.Multiply:
                return Multiply(Number1, Number2);
            case MathOperation.Divide:
                return Divide(Number1, Number2);
            default:
                return null;
        }
    }
    
    private int Add(int a, int b) => a + b;

    private int Subtract(int a, int b) => a - b;

    private int Multiply(int a, int b) => a * b;

    private int? Divide(int a, int b)
    {
        if (b != 0) return a / b;
        ErrorMessage = "Hiba: Nullával való osztás nem megengedett.";
        return null;
    }
}
