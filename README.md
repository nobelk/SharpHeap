# SharpHeap

A C# library providing generic Min Heap and Max Heap implementations built on top of .NET's `PriorityQueue<TElement, TPriority>`.

## Features

- **MinHeap<T>**: Generic min heap data structure for efficient minimum element retrieval
- **MaxHeap<T>**: Generic max heap data structure for efficient maximum element retrieval
- **Type-safe**: Fully generic implementation supporting any type
- **Performance**: Built on .NET's optimized `PriorityQueue` for O(log n) insertions and deletions
- **Simple API**: Clean, intuitive interface with Add, Peek, and Get operations

## Prerequisites

- .NET 10.0 SDK or later
- Compatible with .NET 6.0+ (adjust `TargetFramework` in project files if needed)

## Project Structure

```
SharpHeap/
├── src/
│   ├── MinHeap.cs           # Min heap implementation
│   ├── MaxHeap.cs           # Max heap implementation
│   └── MaxHeapComparer.cs   # Custom comparer for max heap ordering
├── tests/
│   ├── HeapTests.cs         # Comprehensive unit tests
│   └── HeapTests.csproj     # Test project file
├── heap.csproj              # Main library project file
├── README.md                # This file
└── LICENSE                  # Apache License 2.0
```

## Building

### Build the library

```bash
dotnet build heap.csproj
```

### Build the test project

```bash
dotnet build tests/HeapTests.csproj
```

### Build both projects

```bash
dotnet build heap.csproj && dotnet build tests/HeapTests.csproj
```

## Testing

The project includes comprehensive unit tests using xUnit.

### Run all tests

```bash
dotnet test tests/HeapTests.csproj
```

### Run tests with detailed output

```bash
dotnet test tests/HeapTests.csproj --verbosity normal
```

### Test coverage

The test suite includes 17 tests covering:
- **MinHeap tests**: Single/multiple elements, ascending order, duplicate priorities, negative values
- **MaxHeap tests**: Single/multiple elements, descending order, duplicate priorities, negative values
- **MaxHeapComparer tests**: Comparison logic validation

## Usage

### MinHeap Example

```csharp
using DefaultNamespace;

// Create a min heap
var minHeap = new MinHeap<string>();

// Add elements with priorities
minHeap.Add("Low priority task", 10);
minHeap.Add("High priority task", 1);
minHeap.Add("Medium priority task", 5);

// Peek at the minimum (highest priority) element
string next = minHeap.Peek(); // Returns "High priority task"

// Get and remove the minimum element
string min = minHeap.GetMin(); // Returns "High priority task"
min = minHeap.GetMin();        // Returns "Medium priority task"
min = minHeap.GetMin();        // Returns "Low priority task"
```

### MaxHeap Example

```csharp
using DefaultNamespace;

// Create a max heap
var maxHeap = new MaxHeap<int>();

// Add elements with priorities
maxHeap.Add(100, 10);
maxHeap.Add(50, 5);
maxHeap.Add(200, 20);

// Peek at the maximum element
int top = maxHeap.Peek(); // Returns 200

// Get and remove the maximum element
int max = maxHeap.GetMax(); // Returns 200
max = maxHeap.GetMax();     // Returns 100
max = maxHeap.GetMax();     // Returns 50
```

## API Reference

### MinHeap<T>

| Method | Description |
|--------|-------------|
| `void Add(T node, int val)` | Adds an element to the heap with the specified priority |
| `T Peek()` | Returns the minimum element without removing it |
| `T GetMin()` | Removes and returns the minimum element |

### MaxHeap<T>

| Method | Description |
|--------|-------------|
| `void Add(T node, int val)` | Adds an element to the heap with the specified priority |
| `T Peek()` | Returns the maximum element without removing it |
| `T GetMax()` | Removes and returns the maximum element |

## Implementation Details

- **MinHeap**: Uses the default `PriorityQueue<T, int>` behavior, which orders elements by ascending priority
- **MaxHeap**: Uses `MaxHeapComparer` to invert the comparison, ordering elements by descending priority
- **Complexity**: O(log n) for Add operations, O(log n) for Get operations, O(1) for Peek operations

## License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE) file for details
