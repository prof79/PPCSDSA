//----------------------------------------------------------------------------
// <copyright file="BinarySearchTreeNode.cs"
//      company="Markus M. Egger">
//      Copyright (C) 2018 Markus M. Egger. All rights reserved.
// </copyright>
// <author>Markus M. Egger</author>
// <description>
//      A basic implementation of a tree node in a binary search tree
//      with two children ("left" and "right").
//      A search tree demands a specific order and structure of child nodes.
// </description>
// <version>v0.9.6 2018-08-07T23:49:00+02</version>
//----------------------------------------------------------------------------

namespace at.markusegger.Lab.Library.DataStructures
{
    using System;
    using System.Diagnostics;

    using Extensions;

    /// <summary>
    /// A basic implementation of a tree node in a binary search tree
    /// with two children ("left" and "right").
    /// A search tree demands a specific order and structure of child nodes.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the data contained in the tree nodes.
    /// </typeparam>
    public class BinarySearchTreeNode<T>
        : BinaryTreeNodeBase<IBinarySearchTreeNode<T>, T>
        , IBinarySearchTreeNode<T>
        where T : IComparable<T>
    {
        #region Interface IBinarySearchTreeNode<T>

        /// <summary>
        /// Gets whether this is a valid binary search
        /// (sub)-tree or not ie. all nodes follow the
        /// lesser/greater rules of a binary search tree.
        /// </summary>
        public bool IsValidSearchTree
            => ValidateSearchTree(this);

        /// <summary>
        /// Find some data in a binary search tree using binary search.
        /// </summary>
        /// <param name="data">
        /// The data to search for.
        /// </param>
        /// <param name="lastNodeVisited">
        /// Will be filled with the last node visited. If the return value
        /// is "true" than this is the matching node or result.
        /// In case of "false" this is the last node investigated before
        /// stopping the search. Having this reference is essential
        /// for node insertion and removal scenarios.
        /// </param>
        /// <param name="safetyCheck">
        /// Check whether the (sub-)tree is a valid binary search tree
        /// at all before searching. Throws <see cref="InvalidOperationException"/>
        /// if invalid. This is a costly operation of O(n)
        /// for valid trees but spares you an extra check of
        /// "IsValidSearchTree" if you had done so anyway.
        /// </param>
        /// <returns>
        /// True if the data was found otherwise false.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the (sub-)tree is not a valid binary search tree by
        /// definition AND "safetyCheck" was set to "true".
        /// </exception>
        public bool Find(T data, out IBinarySearchTreeNode<T> lastNodeVisited, bool safetyCheck = false)
        {
            lastNodeVisited = this;

            Debug.WriteLine($"BST {nameof(Find)}: Searching for '{data}' from '{this}' ...");

            // Safety check requested - won't search an invalid BST
            if (safetyCheck)
            {
                if (!IsValidSearchTree)
                {
                    throw new InvalidOperationException(
                        $"{nameof(IBinarySearchTreeNode<T>)}.{nameof(Find)}: "
                        + $"This is an invalid binary search tree and {nameof(safetyCheck)} was set to {true}. "
                        + "Search aborted.");
                }
            }

            // Data found
            if (data.CompareTo(Data) == 0)
            {
                Debug.WriteLine($"BST {nameof(Find)}: Data ({data}) match found!");

                return true;
            }

            // Supplied data is lesser than current node's data
            if (data.CompareTo(Data) < 0)
            {
                Debug.WriteLine($"BST {nameof(Find)}: {(this.Left == null ? "No left child." : "Search left sub-tree ...")}");

                // Lesser means we have to go left
                // If there isn't a left node the data could not be found.
                return
                    this.Left == null
                        ? false
                        : this.Left.Find(data, out lastNodeVisited);
            }

            // Supplied data is greater than current node's data
            if (data.CompareTo(Data) > 0)
            {
                Debug.WriteLine($"BST {nameof(Find)}: {(this.Right == null ? "No right child." : "Search right sub-tree ...")}");

                // Greater means we have to go right
                // If there isn't a right node the data could not be found.
                return
                    this.Right == null
                        ? false
                        : this.Right.Find(data, out lastNodeVisited);
            }

            Debug.WriteLine($"BST {nameof(Find)}: Search for '{data}' unsuccessful.");

            return false;
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Checks whether a specific (sub-)tree beginning with
        /// rootNode is a valid binary search tree (BST) or not.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the data contained in the nodes.
        /// </typeparam>
        /// <param name="rootNode">
        /// The root node of the (sub-)tree to validate downwards.
        /// </param>
        /// <param name="minValue">
        /// The minimum value. The node's data must be greater or equal.
        /// Since only few types have a "MinValue" the parameter
        /// demands the data to be encapsulated in a tree node
        /// such that a "null" argument can stand in for an
        /// arbitrary minimum value.
        /// This method uses the corridor/range technique so each
        /// node has to be visited only once (O(n)).
        /// The minimum is adapted accordingly during the recursion downwards.
        /// </param>
        /// <param name="maxValue">
        /// The maximum value. The node's data must be lesser.
        /// Since only few types have a "MaxValue" the parameter
        /// demands the data to be encapsulated in a tree node
        /// such that a "null" argument can stand in for an
        /// arbitrary maximum value.
        /// This method uses the corridor/range technique so each
        /// node has to be visited only once (O(n)).
        /// The maximum is adapted accordingly during the recursion downwards.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool ValidateSearchTree<T>(
            IBinarySearchTreeNode<T> rootNode,
            IBinarySearchTreeNode<T> minValue = null,
            IBinarySearchTreeNode<T> maxValue = null)
            where T : IComparable<T>
        {
            // It doesn't make much sense to validate a null root.
            if (rootNode == null)
            {
                throw new ArgumentNullException(nameof(rootNode));
            }

            Debug.WriteLine($"START {nameof(ValidateSearchTree)}: Searching from node '{rootNode?.ToString()}' ...");
            Debug.WriteLine($"{nameof(ValidateSearchTree)}: Lower bound: '{minValue?.ToString()}'");
            Debug.WriteLine($"{nameof(ValidateSearchTree)}: Upper bound: '{maxValue?.ToString()}'");

            // Check the lower bound/minimum condition.
            // Null is a stand-in for an arbitrary minimum of any type
            // thus rootNode is always greater (true).
            var validLowerBound =
                minValue == null
                ? true
                : rootNode.Data.CompareTo(minValue.Data) >= 0;

            Debug.WriteLine($"{nameof(ValidateSearchTree)}: Within lower bound? {validLowerBound}");

            // Check the upper bound/maximum condition.
            // Null is a stand-in for an arbitrary maximum of any type
            // thus rootNode is always lesser (true).
            var validUpperBound =
                maxValue == null
                ? true
                : rootNode.Data.CompareTo(maxValue.Data) < 0;

            Debug.WriteLine($"{nameof(ValidateSearchTree)}: Within upper bound? {validUpperBound}");

            // If current node's data is not within the corridor of the
            // ancestor nodes then this is not a valid BST.
            if (!(validLowerBound && validUpperBound))
            {
                Debug.WriteLine($"END {nameof(ValidateSearchTree)}: Out-of-bounds, invalid BST.");

                return false;
            }

            Debug.WriteLine($"{nameof(ValidateSearchTree)}: Validating left child ...");

            // The validity of the left part of the tree -
            // automatically true if no child.
            var leftState =
                rootNode.Left == null
                ? true
                : ValidateSearchTree(rootNode.Left, minValue, rootNode);

            bool rightState = false;

            // Optimization - if the left sub-tree is invalid the whole BST is
            // invalid regardless of the right sub-tree.
            if (leftState)
            {
                Debug.WriteLine($"{nameof(ValidateSearchTree)}: Validating right child ...");

                // The validity of the right part of the tree -
                // automatically true if no child.
                rightState =
                    rootNode.Right == null
                    ? true
                    : ValidateSearchTree(rootNode.Right, rootNode, maxValue);
            }
            else
            {
                Debug.WriteLine($"{nameof(ValidateSearchTree)}: Left sub-tree invalid, no need to traverse right child.");
            }

            Debug.WriteLine($"END {nameof(ValidateSearchTree)}: Returning validity of sub-trees: {leftState && rightState}");

            // Return the combined state of left and right sub-tree.
            // If both children are null we will automatically return
            // true - because the current root node has already been
            // verified to be in range using the first if statement.
            return leftState && rightState;
        }

        /// <summary>
        /// An unoptimized variant of checking a binary search tree (BST)
        /// for validity. Will traverse the (sub-)tree nodes multiple times
        /// recursively in a factorial manner by always checking the
        /// maximum values on the left and the minimum values on the right.
        /// </summary>
        /// <param name="rootNode">
        /// The (sub-)tree root node to start validating from.
        /// </param>
        /// <returns>
        /// True if the node structure is a valid binary search tree
        /// otherwise false.
        /// </returns>
        [Obsolete]
        private static bool UnoptimizedValidateSearchTree(IBinarySearchTreeNode<T> rootNode)
        {
            // Base case - no children
            if (rootNode.Degree == 0)
            {
                return true;
            }

            // Binary search tree - all values in nodes left of the
            // current node must be smaller or equal.
            if (rootNode.Left?.FindMax().CompareTo(rootNode.Data) > 0)
            {
                return false;
            }

            // Binary search tree - all values in nodes right of the
            // current node must be greater.
            if (rootNode.Right?.FindMin().CompareTo(rootNode.Data) < 1)
            {
                return false;
            }

            // Else, check children sub-trees.
            var leftState = rootNode.Left == null
                || rootNode.Left.IsValidSearchTree;

            var rightState = rootNode.Right == null
                || rootNode.Right.IsValidSearchTree;

            return leftState && rightState;
        }

        #endregion
    }
}
