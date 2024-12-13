using System.Text;

namespace DemoApp.SharedKernel.Utilities
{
    public static class CsvExporter
    {
        public static byte[] ExportToCsv<T>(IEnumerable<T> data)
        {
            var csv = new StringBuilder();
            var properties = typeof(T).GetProperties();

            // Add header
            csv.AppendLine(string.Join(",", properties.Select(p => p.Name)));

            // Add rows
            foreach (var item in data)
            {
                var values = properties.Select(p => p.GetValue(item)?.ToString() ?? string.Empty);
                csv.AppendLine(string.Join(",", values));
            }

            return Encoding.UTF8.GetBytes(csv.ToString());
        }
    }
}
