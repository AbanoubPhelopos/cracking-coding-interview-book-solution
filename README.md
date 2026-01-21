# 📚 Cracking the Coding Interview - C# Solutions

[![C#](https://img.shields.io/badge/Language-C%23-purple.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-10.0-blue.svg)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](http://makeapullrequest.com)

Complete solutions for **"Cracking the Coding Interview" by Gayle Laakmann McDowell** implemented in **C#** with detailed explanations, examples, and time/space complexity analysis.

---

## 📖 About This Repository

This repository contains comprehensive C# solutions for all 17 chapters of the renowned coding interview preparation book. Each solution includes:

- ✅ **Clean, readable C# code** following best practices
- ✅ **Detailed explanations** of the approach and logic
- ✅ **Time and space complexity analysis**
- ✅ **Multiple solution approaches** where applicable
- ✅ **Unit tests** for validation
- ✅ **Example walkthroughs** with step-by-step execution

---

## 📂 Chapter Overview

| Chapter | Topic | Problems | Status |
|:-------:|-------|:--------:|:------:|
| 01 | [Arrays and Strings](./src/Chapter01_ArraysAndStrings/) | 1/9 | � |
| 02 | [Linked Lists](./src/Chapter02_LinkedLists/) | 0/8 | 🔜 |
| 03 | [Stacks and Queues](./src/Chapter03_StacksAndQueues/) | 0/6 | 🔜 |
| 04 | [Trees and Graphs](./src/Chapter04_TreesAndGraphs/) | 0/12 | 🔜 |
| 05 | [Bit Manipulation](./src/Chapter05_BitManipulation/) | 0/8 | 🔜 |
| 06 | [Math and Logic Puzzles](./src/Chapter06_MathAndLogicPuzzles/) | 0/10 | 🔜 |
| 07 | [Object-Oriented Design](./src/Chapter07_ObjectOrientedDesign/) | 0/12 | 🔜 |
| 08 | [Recursion and Dynamic Programming](./src/Chapter08_RecursionAndDP/) | 0/14 | 🔜 |
| 09 | [System Design and Scalability](./src/Chapter09_SystemDesign/) | 0/8 | 🔜 |
| 10 | [Sorting and Searching](./src/Chapter10_SortingAndSearching/) | 0/11 | 🔜 |
| 11 | [Testing](./src/Chapter11_Testing/) | 0/6 | 🔜 |
| 12 | [C and C++](./src/Chapter12_CAndCPlusPlus/) | 0/11 | 🔜 |
| 13 | [Java](./src/Chapter13_Java/) | 0/8 | 🔜 |
| 14 | [Databases](./src/Chapter14_Databases/) | 0/7 | 🔜 |
| 15 | [Threads and Locks](./src/Chapter15_ThreadsAndLocks/) | 0/7 | 🔜 |
| 16 | [Moderate Problems](./src/Chapter16_Moderate/) | 0/26 | 🔜 |
| 17 | [Hard Problems](./src/Chapter17_Hard/) | 0/26 | 🔜 |

**Legend:** ✅ Complete | 🚧 In Progress | 🔜 Coming Soon

---

## 📋 Chapter 01: Arrays and Strings

| # | Problem | Solution | Tests | Difficulty |
|:-:|---------|:--------:|:-----:|:----------:|
| 1.1 | [Is Unique](./src/Chapter01_ArraysAndStrings/Problem01_IsUnique/) | ✅ | ✅ | Easy |
| 1.2 | Check Permutation | 🔜 | 🔜 | Easy |
| 1.3 | URLify | 🔜 | 🔜 | Easy |
| 1.4 | Palindrome Permutation | 🔜 | 🔜 | Easy |
| 1.5 | One Away | 🔜 | 🔜 | Medium |
| 1.6 | String Compression | 🔜 | � | Easy |
| 1.7 | Rotate Matrix | 🔜 | 🔜 | Medium |
| 1.8 | Zero Matrix | 🔜 | 🔜 | Medium |
| 1.9 | String Rotation | 🔜 | 🔜 | Easy |

---

## �🚀 Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later
- Any C# IDE (Visual Studio, VS Code, Rider)

### Clone the Repository

```bash
git clone https://github.com/AbanoubPhelopos/cracking-coding-interview-book-solution.git
cd cracking-coding-interview-book-solution
```

### Build and Run

```bash
# Build all solutions
dotnet build

# Run all tests
dotnet test

# Run tests with verbose output
dotnet test --logger "console;verbosity=detailed"
```

---

## 📁 Project Structure

```
cracking-coding-interview-book-solution/
├── src/
│   ├── Chapter01_ArraysAndStrings/
│   │   ├── Problem01_IsUnique/
│   │   │   ├── Solution.cs          # Implementation with multiple approaches
│   │   │   └── README.md            # Problem explanation & complexity analysis
│   │   ├── Problem02_CheckPermutation/
│   │   └── Chapter01_ArraysAndStrings.csproj
│   ├── Chapter02_LinkedLists/
│   └── ...
├── tests/
│   ├── Chapter01_ArraysAndStrings.Tests/
│   │   ├── Problem01_IsUniqueTests.cs
│   │   └── Chapter01_ArraysAndStrings.Tests.csproj
│   └── ...
├── CrackingTheCode.sln
└── README.md
```

---

## 🎯 Key Topics Covered

<details>
<summary><b>Data Structures</b></summary>

- Arrays & Strings
- Linked Lists (Singly, Doubly, Circular)
- Stacks & Queues
- Trees (Binary, BST, AVL, Tries)
- Graphs (BFS, DFS, Dijkstra)
- Hash Tables
- Heaps

</details>

<details>
<summary><b>Algorithms</b></summary>

- Sorting (Quick, Merge, Heap)
- Searching (Binary Search, etc.)
- Recursion & Backtracking
- Dynamic Programming
- Greedy Algorithms
- Bit Manipulation

</details>

<details>
<summary><b>Concepts</b></summary>

- Big O Notation
- Object-Oriented Design
- System Design
- Database Design
- Threading & Concurrency

</details>

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## ⭐ Show Your Support

If you find this repository helpful, please consider giving it a ⭐ star!

---

<p align="center">
  Made with ❤️ by <a href="https://github.com/AbanoubPhelopos">Abanoub Saweris</a>
</p>