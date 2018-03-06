# Replacement-of-Iconable-with-custom-shallow-and-deep-copy

Reason for custom implementation
1. ICloneable interface doesn't provide the implementation details which hides whether the returned object is shallow or deep copy.
2. Returned object is of system type which have to downcast to our particular type. 

The above can be avoided by using custom implementation which was demonstrated in this example

shallow copy is creating a new object, and then copying the nonstatic fields of the current object to the new object. 
If a field is a value type, a bit-by-bit copy of the field is performed. If a field is a reference type, the reference is copied 
but the referred object is not; therefore, the original object and its clone refer to the same object.

Deep copy is creating a new object which includes both value and reference type are duplicated. The cloned object doenst have any 
reference to the source object.
