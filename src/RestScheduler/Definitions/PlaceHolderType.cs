namespace RestScheduler.Definitions;

public enum PlaceHolderType
{
    None,
    // {Word}
    Brace,
    // [Word]
    SquareBracket,
    // <Word>
    AngleBracket,
    // (Word)
    Parenthesis,
    // @Word
    AtSign,
    // %Word
    PercentSign
}