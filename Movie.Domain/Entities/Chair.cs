namespace Movie.Domain.Entities;

public class Chair
{
    public Chair(int index, int sizeByCollumn = 5)
    {
        SizeByCollumn = sizeByCollumn;
        Index = index;
        GenerateName();
    }

    public int SizeByCollumn { get; set; }

    public string Name => GenerateName();

    public int Index { get; set; }

    public string GenerateName()
    {
        var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        // get the letter like A1 A2 A3 A4 A5 B1 B2 B3 B4 B5
        var letter = letters[Index / SizeByCollumn];
        var value = Index % SizeByCollumn + 1;
        return string.Format("{0}{1}", letter, value);
    }
}
