namespace Movie.Domain.Entities;

public class Chair
{
    public Chair(int index, int sizeByCollumn = 20)
    {
        SizeByCollumn = sizeByCollumn;
        Index = index;
    }

    public int SizeByCollumn { get; set; }

    public string Name => GenerateName();

    public int Index { get; set; }

    public string GenerateName()
    {
        var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var letter = letters[Index / SizeByCollumn];
        var value = Index % SizeByCollumn + 1;
        return string.Format("{0}-{1}", letter, value);
    }
}
