namespace MobileKeypad
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(OldPhonePad("33#"));
			Console.WriteLine(OldPhonePad("4433555 555666#"));
			Console.WriteLine(OldPhonePad("8 88777444666*664#"));
			Console.WriteLine(OldPhonePad("227*#"));
			Console.ReadKey();
		}
		/*
		    OldPhonePad(“33#”) => output: E
		    OldPhonePad(“227*#”) => output: B
		    OldPhonePad(“4433555 555666#”) => output: HELLO
		    OldPhonePad(“8 88777444666*664#”) => output: ?????
		 */
		static string OldPhonePad(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return string.Empty;
			}
			for(var i=0;i<input.Length;i++)
			{
				if(input[i]=='*')
				{
					input = input.Remove(i - 1, 1);
				}
			}
			var phonePad = new Dictionary<int, char[]>
			{
				{
					2, [
						'A', 'B', 'C'
					]
				},
				{
					3, [
						'D', 'E', 'F'
					]
				},
				{
					4, [
						'G', 'H', 'I'
					]
				},
				{
					5, [
						'J', 'K', 'L'
					]
				},
				{
					6, [
						'M', 'N', 'O'
					]
				},
				{
					7, [
						'P', 'Q', 'R', 'S'
					]
				},
				{
					8, [
						'T', 'U', 'V'
					]
				},
				{
					9, [
						'W', 'X', 'Y', 'Z'
					]
				}
			};

			var result = string.Empty;
			var lastChar = input[0];
			for (var i = 0; i < input.Length; i++)
			{
				if (input[i] == ' ')
				{
					result += "";
					continue;
				}
				if (input[i] == '#')
				{
					continue;
				}
				if (char.IsDigit(input[i]))
				{
					int count = 0;
					while (input[i] == input[i + 1])
					{
						count++;
						i++;
					}
					var key = int.Parse(input[i].ToString());
					var charArray = phonePad[key];
					result += charArray[count];
				}
			}

			return result;
		}
	}
}
