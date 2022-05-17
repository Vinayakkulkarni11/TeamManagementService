namespace TeamManagementService.Extensions
{
    public static class ExtensionMethods
    {
        public static void SetEnumStringConverter(this ModelBuilder modelBuilder)
        {
            var properties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => (Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType).IsEnum);

            foreach (var property in properties)
                property.SetProviderClrType(typeof(string));
        }  

    }
}
