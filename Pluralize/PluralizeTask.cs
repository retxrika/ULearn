namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
			if (count % 100 >= 10 && count % 100 <= 20 || count % 10 >= 5 
				&& count % 10 <= 9 || count % 10 == 0)
				return "рублей";
			
			if (count % 10 >= 2 && count % 10 <= 4)
				return "рубля";
		
			return "рубль";
		}
	}
}

/// 1 рубль
/// 2 рубля
/// 5 рублей
/// 21 рубль
/// 22 рубля
/// 25 рублей
/// 31 рубль
/// 35 рублей
/// 111 рублей
/// 121 рубль
/// 211 рублей
