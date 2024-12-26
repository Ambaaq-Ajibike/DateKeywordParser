# 📦 **DateKeywordParser**

A lightweight **C# Console Application** designed to dynamically resolve date-related keywords in file names, such as `NOW`, `YESTERDAY`, `NOW+1d`, and `Format(NOW, "yyyy-MM-dd")`. Ideal for scenarios like processing FTP files, generating logs, and scheduling automated tasks.

---

## 🚀 **Features**

✅ **Keyword Parsing:** Supports keywords like:  
- `NOW`, `YESTERDAY`, `TODAY`  
- Relative offsets: `NOW+1d`, `NOW-2h`  
- Formatted dates: `Format(NOW, "yyyy-MM-dd")`

✅ **Localization Support:** Custom date formatting based on specified cultures.

✅ **Lightweight:** Minimal dependencies for fast integration.

✅ **Reusable:** Designed for flexibility across different projects and scenarios.

---

## 🛠️ **Setup and Installation**

1. Clone the repository:
```bash
git clone https://github.com/Ambaaq-Ajibike/DateKeywordParser.git
```
2. Open the solution in Visual Studio.
3. Build and run the console application.

---

## 📚 **Usage**

### Basic Example

```csharp
using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        string template1 = "backup_NOW.sql";
        string template2 = "logs_NOW-1d.txt";
        string template3 = "report_YESTERDAY.csv";
        string template4 = "snapshot_Format(NOW, \"yyyy-MM-dd\").json";

        Console.WriteLine(DateKeywordParser.Parse(template1));
        Console.WriteLine(DateKeywordParser.Parse(template2));
        Console.WriteLine(DateKeywordParser.Parse(template3));
        Console.WriteLine(DateKeywordParser.Parse(template4, new CultureInfo("fr-FR")));
    }
}
```

### 📝 **Output Example:**
```
backup_2024-06-25_14-30-00.sql
logs_2024-06-24.txt
report_2024-06-24.csv
snapshot_2024-06-25.json
```

---

## 📑 **Supported Keywords**

| **Keyword**    | **Description**                                   | **Example**              |
|-----------------|---------------------------------------------------|---------------------------|
| `NOW`          | Current date and time                             | `backup_NOW.sql`          |
| `YESTERDAY`    | Date of the previous day                          | `logs_YESTERDAY.txt`      |
| `NOW+1d`       | Current date + 1 day                              | `data_NOW+1d.csv`         |
| `NOW-2h`       | Current time - 2 hours                            | `snapshot_NOW-2h.json`    |
| `Format(NOW, pattern)` | Custom date formatting using patterns    | `report_Format(NOW, "yyyy-MM-dd").txt` |

### 🛠️ **Custom Formats:**
- `yyyy`: Year (e.g., 2024)  
- `MM`: Month (e.g., 06)  
- `dd`: Day (e.g., 25)  
- `HH`: Hour (e.g., 14)  
- `mm`: Minute (e.g., 30)  
- `ss`: Second (e.g., 00)  

---

## 🌐 **Localization Support**

You can specify a culture for date formatting:

```csharp
using System.Globalization;

string result = DateKeywordParser.Parse("snapshot_Format(NOW, \"dddd, dd MMMM yyyy\").json", new CultureInfo("fr-FR"));
Console.WriteLine(result);
```

**Output:**  
```
snapshot_mardi, 25 juin 2024.json
```

---

## 🛡️ **Error Handling**

- Invalid date offsets (e.g., `NOW+Xd`) are ignored.  
- Invalid format strings in `Format(NOW, ...)` will throw a `FormatException`.

---

Happy Coding! 🚀✨

