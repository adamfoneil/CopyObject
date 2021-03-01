The idea here is to copy one object to another or to a new instance, typically from some kind of DTO to a database model class or vice versa via extension method. For example

```csharp
using CopyObjectLibrary;

...

var dest = source.CopyAs<SomeType>();
```
This would copy matching properties of `source` to a new instance of type `SomeType dest`.

This mapper requires properties to be identically-named and a type that's [close enough](https://github.com/adamfoneil/CopyObject/blob/master/CopyObject/TypeExtensions.cs#L12). "Close enough" means `T` == `T` but also `T` == `Nullable<T>` or `Nullable<T>` == `T`.

See examples in [tests](https://github.com/adamfoneil/CopyObject/blob/master/Testing/CopyTests.cs).

# Reference
## CopyObjectLibrary.ObjectExtensions [ObjectExtensions.cs](https://github.com/adamfoneil/CopyObject/blob/master/CopyObject/ObjectExtensions.cs#L7)
### Methods
- [T](https://github.com/adamfoneil/CopyObject/blob/master/CopyObject/ObjectExtensions.cs#L14) [CopyAs](https://github.com/adamfoneil/CopyObject/blob/master/CopyObject/ObjectExtensions.cs#L14)
 (this object object)
- [T](https://github.com/adamfoneil/CopyObject/blob/master/CopyObject/ObjectExtensions.cs#L20) [CopyAs](https://github.com/adamfoneil/CopyObject/blob/master/CopyObject/ObjectExtensions.cs#L20)<T>
 (this object object, T instance)
- void [CopyTo](https://github.com/adamfoneil/CopyObject/blob/master/CopyObject/ObjectExtensions.cs#L39)<T>
 (this object object, T instance)
- bool [Equals](https://github.com/adamfoneil/CopyObject/blob/master/CopyObject/ObjectExtensions.cs#L43)
 (PropertyInfo x, PropertyInfo y)
- int [GetHashCode](https://github.com/adamfoneil/CopyObject/blob/master/CopyObject/ObjectExtensions.cs#L46)
 (PropertyInfo obj)

## CopyObjectLibrary.TypeExtensions [TypeExtensions.cs](https://github.com/adamfoneil/CopyObject/blob/master/CopyObject/TypeExtensions.cs#L6)
### Methods
- bool [IsSimpleType](https://github.com/adamfoneil/CopyObject/blob/master/CopyObject/TypeExtensions.cs#L8)
 (this Type type)
- bool [IsNullableGeneric](https://github.com/adamfoneil/CopyObject/blob/master/CopyObject/TypeExtensions.cs#L10)
 (this Type type)
- bool [IsTypeCloseEnough](https://github.com/adamfoneil/CopyObject/blob/master/CopyObject/TypeExtensions.cs#L12)
 (this Type type, Type compareWith)
