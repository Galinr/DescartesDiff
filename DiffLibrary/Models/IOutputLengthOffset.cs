namespace DiffLibrary.Models
{
    public interface IOutputLengthOffset : IOutput
    {
        int Length { get; set; }
        int Offset { get; set; }
    }
}