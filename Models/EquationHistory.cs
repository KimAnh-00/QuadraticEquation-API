namespace QuadraticEquation.Models
{
    public class EquationHistory
    {
        public int Id { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double Delta { get; set; }
        public string Result { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class SolveRequest
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
    }
}