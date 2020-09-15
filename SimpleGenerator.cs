using System;
using System.Text;

namespace SimpleHash
{
	public class SimpleGenerator
	{
		public readonly long salt;
		
		public SimpleGenerator()
		{
			salt = (long) DateTime.Now.Subtract(new DateTime(1970, 1, 1, 1, 1, 1)).TotalMilliseconds;
		}
		
		string[] splitStringSize(string input, int chunkSize)
		{
			string tempstring = input;
			while(tempstring.Length < 128)
				tempstring += input;
			input = tempstring;
			
			int amounts = (int) Math.Ceiling((input.Length / chunkSize) * 1.0);
			string[] result = new string[amounts];
			
			// add one chunk of zeroes to ensure substrings can be captured
			// cheap n dirty solution
			for(int i = 0; i < chunkSize; i++)
				input += "0";
			
			for(int i = 0; i < amounts; i++)
				result[i] = input.Substring(i * chunkSize, chunkSize);
			
			return result;
		}
		
		public string Hash(string input, int length)
		{
			if(input.Length < 1)
				return "";
			
			if(length > 64)
				length = 64;
			string[]chunks = splitStringSize(input, 16);
			string[] pieces = new string[chunks.Length];
			
			for (int i = 0; i < chunks.Length; i++)
			{
				string temp = "";
				for(int u = 0; u < chunks[i].Length; u++)
				{
					temp += Encoding.ASCII.GetBytes(chunks[i].Substring(u, 1))[0].ToString();
				}
				temp = temp.Substring(0, 16);
				pieces[i] = ((long) (Int64.Parse(temp) * 8 / input.Length)).ToString("X");
				// Console.WriteLine("Chunk #{0}: {1}", i, pieces[i]);
			}
			
			string result = "";
			for(int i = 0; i < pieces.Length; i++)
				result += pieces[i];
			
			return result.Substring(0,length);
		}
	}
}