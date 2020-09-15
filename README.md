# shash

Consider the following scenario: a person only has a very rudimentary idea of how hashing algorithms work, but wants to code their own. The start writing stuff until it works, even though they have no idea how to test whether the algorithm works without hash collisions.

This is how shash came to be. So far I haven't found any two strings that result in identical hashes. Take a good look at the code, have a laugh at my expense, look elsewhere. Really, I'm just putting this up here for archiving purposes.

# How it works

It doesn't, probably.

# How it works (for real)

First of all, the input string is brought to a length of at least 128 chars by simply being duplicated until the string lenghth surpassses 128. Then, it is divided into chunks of 16 characters. The ASCII numerical values of each char in the string are then written one after another, parsed as Int64, multiplied with 8 and divided by the length of the input. These pieces, written as hex, are then pieced together for all the chunks, and truncated after 64, equal 256 bits.

The chunk size (default: 16) and hash size (capped at 64 hex / 256 bits) are variably.

# Methods

`private string[] SimpleGenerator.splitStringSize (string input, int chunkSize)`

Splits any given string into chunks of the given length. Zeroes are applied at the end to fill up whatever gap is left to a full chunk.

`public string Hash (string input, int length)`

Calculates a hash for the given input, of the given length (maximum: 64).

`public SimpleGenerator ()`

Constructor. Creates a salt because I had no clue what a salt was good for. Said salt is then never used again. Basically obsolete to be quite honest.
