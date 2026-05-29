# Corrección — FaustinoTrivelli

> **Aviso importante:** Las soluciones se evalúan exclusivamente con los conceptos vistos en clase. Si se utilizan conceptos que no fueron parte del programa (frameworks externos, técnicas avanzadas no vistas, etc.), esas partes no serán tenidas en cuenta en la corrección.

## Nota general
**No aprobado** — Puntaje: 22/100

| Área | Obtenido | Máximo |
|---|---|---|
| Jerarquía de herencia | 6 | 25 |
| Clase Orden | 3 | 15 |
| BibliotecaService | 4 | 25 |
| Validaciones y excepciones | 5 | 15 |
| Tests unitarios | 0 | 15 |
| Estructura de proyecto | 4 | 5 |
| **Total** | **22** | **100** |

## Correcciones de evaluación

### 1. Jerarquía de herencia — 6/25

- La clase base se llama `Catalogo` (no `Libro`). **No es abstracta** — falta la keyword `abstract`. Penalización grave. (0/5)
- El método abstracto está declarado como `public abstract CalcularPrecioFinal();` — **sin tipo de retorno**. Esta sintaxis no compila en C#. (0/5)
- `LibrosComprados` hereda de `Catalogo`, tiene `Formato`. El override tiene firma `public override decimal CalcularPrecioFinal(decimal precioBase)` — con parámetro adicional, que **no es un override válido** del método base sin parámetros. La fórmula `precioBase + precioBase * 0.10` es correcta en concepto (sin sufijo `m`). (2/7)
- `LibrosAlquilados` hereda de `Catalogo`, tiene `DiasAlquiler`. Override con firma `CalcularPrecioFinal(decimal precioBase, int diasAlquiler)` — dos parámetros adicionales, tampoco es override válido. La fórmula aplica `resultado * 0.15` como precio final en lugar de `resultado * 0.85` — **error de fórmula**: calcula solo el 15% del total en lugar del 85%. (0/8)
- Los constructores de ambas subclases llaman `base(...)` correctamente.
- Se otorgan 6 pts por el intento de herencia, constructores con llamada a base y la presencia de propiedades `Formato` y `DiasAlquiler`.

### 2. Clase Orden — 3/15

- No usa `Guid.NewGuid()`. El campo `IDunico` recibe `id` como parámetro del constructor pero el código usa `IDunico = id++` — `id` es el parámetro, no una variable estática, lo que genera comportamiento incorrecto y probable error de compilación. (0/3)
- `Item` de tipo `Catalogo` (polimorfismo). Correcto conceptualmente. (3/4)
- `TotalPagar` está declarado como `public decimal TotalPagar {get;}` pero **no tiene implementación** — no delega a `CalcularPrecioFinal()`. En C# esto no compila (propiedad sin getter ni cuerpo). (0/5)
- Constructor con bugs de compilación. (0/3)

### 3. BibliotecaService — 4/25

- `BibliotecaService` **hereda de `Orden`** (`public class BibliotecaService : Orden`) — error conceptual grave: un servicio no es una orden. Rompe la compilación porque `Orden` requiere parámetros en su constructor.
- Lista `List<Orden> Historial` sin modificador de acceso (`internal`, no `private`). No encapsulada. (0/5)
- `AgregarOrden(Orden orden)` existe y agrega a la lista. Correcto en concepto. (4/5)
- `BuscarPorOrdenUsuario`: sin tipo de retorno declarado (no compila). La comparación no es case-insensitive. Retorna solo la primera orden encontrada, no una lista. (0/8)
- `ObtenerTotalRecaudado`: contiene `Historial.Catalogo.CalcularPrecioFinal.Sum()` — sintaxis completamente inválida. No compila. (0/7)

### 4. Validaciones y excepciones — 5/15

- ISBN: `if (codISBN == "")` — solo verifica cadena vacía exacta, no whitespace. No usa `IsNullOrWhiteSpace`. Parcial. (0/5)
- `PrecioBase`: el código tiene un bug de llaves `if (precioBase <= 0) {}` (llaves vacías) seguido de un bloque con `throw` suelto que se ejecuta siempre. La excepción se lanza independientemente del valor. La lógica está rota. (0/5)
- `DiasAlquiler <= 0`: `if (diasAlquiler <= 0) { throw new ArgumentException(...) }`. Correcto. (5/5)

### 5. Tests unitarios — 0/15

El archivo `UnitTest1.cs` contiene únicamente el placeholder de NUnit:
```csharp
[Test]
public void Test1()
{
    Assert.Pass();
}
```
No hay ningún test real.

### 6. Estructura de proyecto — 4/5

- Archivo `Solucion2.sln` presente: correcto. (2/2)
- Proyecto classlib `Clases2`: presente. (2/2)
- Proyecto NUnit `Test2` con referencia: se asume presente por la estructura. (0/1)

## Observaciones importantes

- El código en su estado actual **no compila** en ninguna parte principal:
  - El método abstracto no tiene tipo de retorno.
  - Las firmas de `override` tienen parámetros adicionales.
  - `BibliotecaService` hereda de `Orden` requiriendo parámetros imposibles.
  - `ObtenerTotalRecaudado` tiene sintaxis inválida.
  - La validación de `PrecioBase` tiene un bug de llaves que hace que siempre lance excepción.
- La fórmula de `LibrosAlquilados` aplica el 15% como precio final en lugar del descuento del 15% (resultado debería ser el 85% del total).
- Se recomienda revisar la sintaxis básica de C#: tipos de retorno en métodos, firmas de override, y la diferencia entre una clase que hereda y un campo que contiene una referencia.
