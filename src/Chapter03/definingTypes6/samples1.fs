module Strangelights.Sample1
// definition of a tree 
type Tree<'a> =
| Node of Tree<'a> list
| Value of 'a

// create an instance of a tree
let tree2 =
    Node( [ Node( [Value "one"; Value "two"] ) ;
            Node( [Value "three"; Value "four"] ) ] )