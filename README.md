<p align="center">
  <img src="icon.png" width="128" height="128" alt="NanoVector Logo">
</p>

# ⏏NanoVector⚡
## A high-performance, SIMD-accelerated vector library for .NET. Minimalist, zero-allocation, and engineered for raw speed.

## ✨ Key Features

* **🚀 SIMD Accelerated** — Uses hardware intrinsics (AVX/AVX2) to process multiple numbers in a single CPU cycle.
* **💎 Zero Allocations** — Engineered to work with `Span<T>` and `unsafe` pointers. No Garbage Collector overhead.
* **🛠 Raw Speed** — Bypasses standard .NET bounds checking for maximum throughput.
* **🧩 Simple API** — Easy to use for AI, game engines, and math-heavy applications.

## 📥 Installation

Install via NuGet:
`dotnet add package NanoVector`

## 💻 Usage

### 🔧 Basic Operations

* **⏺ Using**
  ```csharp
  using NanoVector;
  ```
* **🚀 Create & Sum** — Create a vector from an array and calculate the total sum using SIMD power.
  ```csharp
  var vector = new MultiVector(new float[] { 1, 2, 3, 4 });
  float result = vector.Sum();
  ```
* **💎 Sum of Squares** — Optimized calculation for AI and statistical variance.
  ```csharp
  float squares = vector.SumOfSquares();
  ```
* **🤖 AI Comparison** — Measure cosine similarity between two vectors for neural networks.
  ```csharp
  float dotProduct = NanoComparator.DotProduct(vector1, vector2);
  float similarity = NanoComparator.Compare(vector1, vector2);
  ```
* **🛡️ Read-Only Safety** — Use `ReadOnlyMultiVector` for safe data processing without accidental modifications.
  ```csharp
  ReadOnlyMultiVector readOnlyVector = vector.AsReadOnly();
  float safeSum = readOnlyVector.Sum();
  float safeSumSquares = readOnlyVector.SumOfSquares();
  ```
### 🧠 Example: Simple Neuron Calculation
This is a conceptual example of how to implement a high-speed neural network layer using **NanoVector**:
```csharp
// Let's represent the input signals and the weight of the neuron
// Input signals and trained weights
var inputs = new MultiVector(new float[] { 0.5f, -0.2f, 0.8f, 0.1f });
var weights = new MultiVector(new float[] { 0.15f, 0.45f, -0.1f, 0.9f });
float bias = 0.05f;

// 1. Compute the dot product using SIMD
// Calculate dot product with hardware acceleration
float dot = NanoComparator.DotProduct(inputs, weights);

// 2. Add bias and apply activation (ReLU)
// Add bias and apply ReLU activation
float neuronOutput = MathF.Max(0, dot + bias);

//Showing the result
Console.WriteLine($"Neuron result: {neuronOutput}");
```
## ☕ Support NanoVector ⚡
If this library saved your nanoseconds, consider a tip:

<table border="0">
  <tr>
    <td align="center">
      <img src="qr-evm.png" width="150"><br>
      <b>ETH / EVM</b><br>
      <code>0x8E0C7...BCc3</code>
    </td>
    <td align="center">
      <img src="qr-btc.png" width="150"><br>
      <b>Bitcoin</b><br>
      <code>bc1qg2g...7lqz</code>
    </td>
    <td align="center">
      <img src="qr-sol.png" width="150"><br>
      <b>Solana</b><br>
      <code>7YBVmUg...MZ1o</code>
    </td>
  </tr>
</table>

* **ETH / Polygon / BSC / Base (EVM):** `0x8E0C732094a1645668609Dc516a2304B8aaaBCc3`
* **Bitcoin (BTC):** `bc1qg2gh4s82yll4cnck26z63ycksngj54kjtz7lqz`
* **Solana (SOL):** `7YBVmUggTMmGH8MQ6HU847PfubAUKMxxw3Cx9NLUMZ1o`
## 🛡️ License

Distributed under the **MIT License**. See `LICENSE` for more information.

---
*Built for nanoseconds. 🧬*