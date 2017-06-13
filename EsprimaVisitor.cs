using System;
using System.Collections.Generic;
using Esprima.Ast;

namespace JavascriptProcessor
{

    
    public abstract class EsprimaVisitor<TContext>
    {
        public virtual void  Visit(ClassDeclaration declaration, TContext context)
        {
            Visit(declaration.Id,context);
            Visit(declaration.Body, context);

        }

        public virtual void  Visit(ClassBody body, TContext context)
        {
            Visit(body.Body, context);
        }

        public virtual void  Visit(IEnumerable<ClassProperty> body, TContext context)
        {
            foreach(var prop in body)
            {
                Visit(prop, context);
            }
        }



        public virtual void  Visit(ClassProperty prop, TContext context)
        {
      
        }

        public virtual void  Visit(VariableDeclaration declaration, TContext context)
        {
            VisitVariables(declaration.Declarations,context);
        }

        public virtual void  VisitVariables(IEnumerable<VariableDeclarator> declarations, TContext context)
        {
            foreach(VariableDeclarator variable in declarations)
            {
                Visit(variable, context);
            }
        }

        public virtual void  Visit(VariableDeclarator variable, TContext context)
        {
            Visit((Identifier)variable.Id);
            if (variable.Init!=null)
                VisitExpression(variable.Init,context);
        }

        public virtual void  Visit(Identifier id)
        {
            
        }

        public virtual void  Visit(FunctionDeclaration declaration,TContext context)
        {
            Visit(declaration.Id, context);
            VisitFunctionParameters(declaration.Params, context);
            Visit(declaration.Body,context);
        }

        public virtual void VisitFunctionParameters(IEnumerable<INode> @params, TContext context)
        {
            foreach(var @param in @params)
            {
                VisitFunctionParameter(@param, context);
            }
        }

        private void VisitFunctionParameter(INode param, TContext context)
        {
            if (param is Esprima.Ast.Identifier)
            {
                Visit((Identifier)param, context);
            }
            else
                throw new NotImplementedException();
        }


        public virtual void  Visit(Identifier id, TContext context)
        {
            
        }

        public virtual void  Visit(BlockStatement body, TContext context)
        {
            VisitBlockStatements(body.Body, context);

        }

        public virtual void  VisitBlockStatements(IEnumerable<StatementListItem> body, TContext context)
        {
            foreach(var statement in body)
            {
                Visit(statement, context);
            }
        }

        public virtual void  Visit(SwitchStatement statement, TContext context)
        {
            VisitExpression(statement.Discriminant, context);
            foreach(var @case in statement.Cases)
            {
                Visit(@case, context);
            }
        }

        public virtual void  Visit(SwitchCase @case, TContext context)
        {
            VisitExpression(@case.Test,context);
            VisitSwitchConsequent(@case.Consequent, context);
            
        }

        public virtual void  VisitSwitchConsequent(IEnumerable<StatementListItem> consequent, TContext context)
        {
            foreach(var st in consequent)
            {
                Visit(st, context);
            }
        }

        public virtual void Visit(Program program, TContext context)
        {
            foreach(var part in program.Body) 
                Visit(part, context);
        }

        public virtual void  Visit(StatementListItem statement, TContext context)
        {
            if (statement is Esprima.Ast.BlockStatement)
            {
                Visit((BlockStatement)statement, context);
            }
            else if (statement is Esprima.Ast.BreakStatement)
            {
                Visit((BreakStatement)statement, context);
            }
            else if (statement is Esprima.Ast.ContinueStatement)
            {
                Visit((ContinueStatement)statement, context);
            }
            else if (statement is Esprima.Ast.DebuggerStatement)
            {
                Visit((DebuggerStatement)statement, context);
            }
            else if (statement is Esprima.Ast.DoWhileStatement)
            {
                Visit((DoWhileStatement)statement, context);
            }
            else if (statement is Esprima.Ast.EmptyStatement)
            {
                Visit((EmptyStatement)statement, context);
            }
            else if (statement is Esprima.Ast.ExportStatement)
            {
                Visit((ExportStatement)statement, context);
            }
            else if (statement is Esprima.Ast.ExpressionStatement)
            {
                Visit((ExpressionStatement)statement, context);
            }
            else if (statement is Esprima.Ast.ForInStatement)
            {
                Visit((ForInStatement)statement, context);
            }
            else if (statement is Esprima.Ast.ForOfStatement)
            {
                Visit((ForOfStatement)statement, context);
            }

            else if (statement is ForStatement)
            {
                Visit((ForStatement)statement, context);
            }
            else if (statement is ForOfStatement)
            {
                Visit((ForOfStatement)statement, context);
            }
            else if (statement is IfStatement)
            {
                Visit((IfStatement)statement, context);
            }
            else if (statement is Esprima.Ast.LabeledStatement)
            {
                Visit((LabeledStatement)statement, context);
            }
            else if (statement is Esprima.Ast.ReturnStatement)
            {
                Visit((ReturnStatement)statement, context);
            }
            else if (statement is Esprima.Ast.SwitchStatement)
            {
                Visit((SwitchStatement)statement, context);
            }
            else if (statement is Esprima.Ast.ThrowStatement)
            {
                Visit((ThrowStatement)statement, context);
            }
            else if (statement is Esprima.Ast.TryStatement)
            {
                Visit((TryStatement)statement, context);
            }
            else if (statement is Esprima.Ast.WhileStatement)
            {
                Visit((WhileStatement)statement, context);
            }
            else if (statement is Esprima.Ast.WithStatement)
            {
                Visit((WithStatement)statement, context);
            }
            else if (statement is Esprima.Ast.FunctionDeclaration)
            {
                Visit((FunctionDeclaration)statement, context);
            }
            else if (statement is Esprima.Ast.VariableDeclaration)
            {
                Visit((VariableDeclaration)statement, context);
            }
            else if (statement is Esprima.Ast.CatchClause)
            {
                Visit((CatchClause)statement, context);
            }

            else throw new NotImplementedException();
        }

        public virtual void Visit(CatchClause catchClause, TContext context)
        {
            if (catchClause.Param != null)
            {
                if (catchClause.Param is Identifier)
                {
                    Visit((Identifier)catchClause.Param, context);
                }
                else
                    throw new NotImplementedException();
            }
            Visit(catchClause.Body, context);
        }


        public virtual void  VisitExpression(Expression expression, TContext context)
        {
            if (expression == null) return;
            if (expression is Esprima.Ast.ArrayExpression)
            {
                Visit((ArrayExpression)expression, context);
            }
            else if (expression is Esprima.Ast.ArrowFunctionExpression)
            {
                Visit((ArrowFunctionExpression)expression, context);
            }
            else if (expression is Esprima.Ast.AssignmentExpression)
            {
                Visit((AssignmentExpression)expression, context);
            }
            else if (expression is Esprima.Ast.BinaryExpression)
            {
                Visit((BinaryExpression)expression, context);
            }
            else if (expression is Esprima.Ast.CallExpression)
            {
                Visit((CallExpression)expression, context);
            }
            else if (expression is Esprima.Ast.ClassExpression)
            {
                Visit((ClassExpression)expression, context);
            }
            else if (expression is Esprima.Ast.ComputedMemberExpression)
            {
                Visit((ComputedMemberExpression)expression, context);
            }
            else if (expression is Esprima.Ast.ConditionalExpression)
            {
                Visit((ConditionalExpression)expression, context);
            }
            else if (expression is Esprima.Ast.FunctionExpression)
            {
                Visit((FunctionExpression)expression, context);
            }
            else if (expression is Esprima.Ast.Identifier)
            {
                Visit((Identifier)expression, context);
            }
            else if (expression is Esprima.Ast.MemberExpression)
            {
                Visit((MemberExpression)expression, context);
            }
            else if (expression is Esprima.Ast.NewExpression)
            {
                Visit((NewExpression)expression, context);
            }
            else if (expression is Esprima.Ast.Literal)
            {
                Visit((Literal)expression, context);
            }
            else if (expression is Esprima.Ast.StaticMemberExpression)
            {
                Visit((StaticMemberExpression)expression, context);
            }
            else if (expression is UnaryExpression)
            {
                Visit((UnaryExpression)expression, context);
            }
            else if (expression is ThisExpression)
            {
                Visit((ThisExpression)expression, context);
            }
            else throw new NotImplementedException();
        }

        public virtual void Visit(MemberExpression memberExpression, TContext context)
        {
            VisitExpression(memberExpression.Object, context);
            VisitExpression(memberExpression.Property, context);
        }

        public virtual void Visit(ThisExpression expression, TContext context)
        {

        }

        public virtual void Visit(UnaryExpression expression, TContext context)
        {

        }

        public virtual void Visit(StaticMemberExpression expression, TContext context)
        {
            VisitExpression(expression.Object,context);
            VisitExpression(expression.Property,context);
        }

        public virtual void Visit(ArrayExpression expression,TContext context)
        {
            foreach(var elem in expression.Elements)
            {
                Visit(elem, context);
            }

        }
        private void Visit(Literal elem, TContext context)
        {

        }

        private void Visit(ArrayExpressionElement elem, TContext context)
        {
            throw new NotImplementedException();
        }

        public virtual void Visit(ArrowFunctionExpression expression, TContext context)
        {
            throw new NotImplementedException();
        }

        public virtual void Visit(AssignmentExpression expression, TContext context)
        {
            VisitAssignmentLeftNode(expression.Left,context);
            VisitExpression(expression.Right, context);

        }

        private void VisitAssignmentLeftNode(INode left, TContext context)
        {
            if (left is Expression)
                VisitExpression((Expression)left, context);
            else    
                throw new NotImplementedException();
        }

        public virtual void Visit(BinaryExpression expression, TContext context)
        {
            VisitExpression(expression.Left, context);
            VisitExpression(expression.Right, context);

        }

        public virtual void Visit(CallExpression call, TContext context)
        {
            VisitExpression(call.Callee, context);
            Visit(call.Arguments, context);
        }

        private void Visit(List<ArgumentListElement> arguments, TContext context)
        {
            if (arguments == null) return;
            foreach(var argument in arguments)
            {
                Visit(argument, context);
            }
        }

        private void Visit(ArgumentListElement argument, TContext context)
        {
            if (argument is Expression)
            {
                VisitExpression((Expression)argument, context);
            }
            else
                throw new NotImplementedException();
        }

        public virtual void Visit(ClassExpression expression, TContext context)
        {
            throw new NotImplementedException();
        }

        public virtual void Visit(ComputedMemberExpression computedExpression, TContext context)
        {
            VisitExpression(computedExpression.Object, context);
            VisitExpression(computedExpression.Property, context);
        }

        public virtual void Visit(ConditionalExpression expression, TContext context)
        {
            throw new NotImplementedException();
        }

        public virtual void Visit(FunctionExpression functionExpression, TContext context)
        {
            Visit(functionExpression.Id,context);
            VisitFunctionExpressionParams(functionExpression.Params, context);
            Visit(functionExpression.Body, context);

        }

        private void VisitFunctionExpressionParams(IEnumerable<INode> @params, TContext context)
        {
            foreach(var @param in @params)
            {
                throw new NotImplementedException();
            }

        }

        public virtual void Visit(NewExpression newExpression, TContext context)
        {
            //          public Expression Callee;
            //public List<ArgumentListElement> Arguments;
            VisitExpression(newExpression.Callee, context);
            Visit(newExpression.Arguments, context);
  
        }


        public virtual void  Visit(ThrowStatement statement, TContext context)
        {
            VisitExpression(statement.Argument, context);
        }

        public virtual void  Visit(TryStatement statement, TContext context)
        {
            Visit(statement.Block,context);
            Visit(statement.Handler, context);
            if (statement.Finalizer!=null)
                Visit(statement.Finalizer, context);
        }

        public virtual void  Visit(WhileStatement statement, TContext context)
        {
            VisitExpression(statement.Test, context);
            Visit(statement.Body, context);
        }

        public virtual void  Visit(WithStatement statement, TContext context)
        {
            VisitExpression(statement.Object, context);
            Visit(statement.Body, context);
        }

        public virtual void  Visit(LabeledStatement statement, TContext context)
        {
            Visit(statement.Label, context);
            Visit(statement.Body, context);
        }

        public virtual void  Visit(ReturnStatement statement, TContext context)
        {
            VisitExpression(statement.Argument, context);
        }

        public virtual void  Visit(ForInStatement statement, TContext context)
        {
            throw new NotImplementedException();
        }

        public virtual void  Visit(ExpressionStatement statement, TContext context)
        {
            VisitExpression(statement.Expression,context);
        }

        public virtual void  Visit(ExportStatement statement, TContext context)
        {
            throw new NotImplementedException();
        }

        public virtual void  Visit(EmptyStatement statement, TContext context)
        {
        }

        public virtual void  Visit(DoWhileStatement statement, TContext context)
        {
            Visit(statement.Body, context);
            VisitExpression(statement.Test, context);
        }

        public virtual void  Visit(DebuggerStatement statement, TContext context)
        {

        }

        public virtual void  Visit(ContinueStatement statement, TContext context)
        {
            throw new NotImplementedException();
        }

        public virtual void  Visit(BreakStatement statement, TContext context)
        {
            if (statement.Label != null)
            Visit(statement.Label,context);
            
        }

        public virtual void  Visit(ForOfStatement statement, TContext context)
        {
            throw new NotImplementedException();
        }

        public virtual void  Visit(ForStatement statement, TContext context)
        {
            VisitForInit(statement.Init, context);
            VisitExpression(statement.Test, context);
            VisitExpression(statement.Update, context);
            Visit(statement.Body, context);
        }

        public virtual void  VisitForInit(INode init, TContext context)
        {
            if (init is Expression)
            {
                VisitExpression((Expression)init, context);
            }
            else
                throw new NotImplementedException();
        }

        public virtual void  Visit(IfStatement statement, TContext context)
        {
            VisitExpression(statement.Test, context);
            Visit(statement.Consequent, context);
            if (statement.Alternate!=null)
            Visit(statement.Alternate, context);

        }
    }
}
