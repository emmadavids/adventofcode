 List<string> separatedList = lines
        .Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries)
        .ToList();


