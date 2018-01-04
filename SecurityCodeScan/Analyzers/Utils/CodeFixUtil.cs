﻿using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace SecurityCodeScan.Analyzers.Utils
{
    public class CodeFixUtil
    {
        /// <summary>
        /// Extract the last indendation from the trivia passed.
        /// </summary>
        /// <param name="leadingTrivia"></param>
        /// <returns></returns>
        public static SyntaxTriviaList KeepLastLine(SyntaxTriviaList leadingTrivia)
        {
            SyntaxTriviaList triviaBuild = SyntaxTriviaList.Empty;
            foreach (SyntaxTrivia trivium in leadingTrivia.Reverse())
            {
                if (!trivium.IsKind(SyntaxKind.WhitespaceTrivia))
                    continue;

                triviaBuild = triviaBuild.Insert(0, trivium);
                break;
            }

            return triviaBuild;
        }

        public static SyntaxNode GetParentNode(SyntaxNode childNode, Type target)
        {
            SyntaxNode node = childNode;

            do
            {
                node = node.Parent;
            } while (node.Parent != null && node.GetType() != target);

            return node.GetType() == target ? node : null;
        }
    }
}
