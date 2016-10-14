module Strangelights.Sample2
// definition of a binary tree 
type 'a BinaryTree =
    | BinaryNode of 'a BinaryTree * 'a BinaryTree
    | BinaryValue of 'a

// create an instance of a binary tree
let tree1 =
    BinaryNode(
        BinaryNode ( BinaryValue 1, BinaryValue 2),
        BinaryNode ( BinaryValue 3, BinaryValue 4) )

// definition of a tree 
type Tree<'a> =
    | Node of Tree<'a> list
    | Value of 'a

// create an instance of a tree
let tree2 =
    Node( [ Node( [Value "one"; Value "two"] ) ;
        Node( [Value "three"; Value "four"] ) ] )

// function to print the binary tree
let rec printBinaryTreeValues x =
    match x with
    | BinaryNode (node1, node2) ->
        printBinaryTreeValues node1
        printBinaryTreeValues node2
    | BinaryValue x -> 
        printf "%A, " x

// function to print the tree
let rec printTreeValues x =
    match x with
    | Node l -> List.iter printTreeValues l
    | Value x ->
        printf "%A, " x
        
// print the results
printBinaryTreeValues tree1
printfn ""
printTreeValues tree2