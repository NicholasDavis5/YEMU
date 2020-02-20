﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YAS
{
    /// <summary>
    /// A Registry of Keyword tokens in the Y86 language.
    /// </summary>
    class Keywords
    {
        private List<Token> keys;

        public Keywords()
        {
            keys = new List<Token>();
            GenerateTokens(ref keys);
        }

        public void AddInstructionToken(List<Token> tokens, string str, EnumInstructions instructionEnum)
        {
            Token tkn = new Token(str);
            tkn.AddProperty(EnumTokenProperties.TokenType, (Int64)EnumTokenTypes.Instruction);
            tkn.AddProperty(EnumTokenProperties.RealInstruction, (Int64)instructionEnum);
            tokens.Add(tkn);
        }

        private void AddRegisterToken(List<Token> tokens, string str, EnumRegisters registerEnum)
        {
            Token tkn = new Token(str);
            tkn.AddProperty(EnumTokenProperties.TokenType, (Int64)EnumTokenTypes.Instruction);
            tkn.AddProperty(EnumTokenProperties.RegisterNumber, (Int64)registerEnum);
            tokens.Add(tkn);
        }

        private void AddAddressRegisterToken(List<Token> tokens, string str, EnumRegisters registerEnum)
        {
            Token tkn = new Token(str);
            tkn.AddProperty(EnumTokenProperties.TokenType, (Int64)EnumTokenTypes.AddressRegister);
            tkn.AddProperty(EnumTokenProperties.RegisterNumber, (Int64)registerEnum);
            tokens.Add(tkn);
        }

        public void GenerateTokens(ref List<Token> tknList)
        {
            //-----Instructions
            tknList.Add(new Token((Int64)EnumTokenTypes.Instruction, (Int64)EnumInstructions.add, "addq"));
            tknList.Add(new Token((Int64)EnumTokenTypes.Instruction, (Int64)EnumInstructions.sub, "subq"));
            tknList.Add(new Token((Int64)EnumTokenTypes.Instruction, (Int64)EnumInstructions.xor, "xorq"));
            AddInstructionToken(tknList, "jmp", EnumInstructions.jmp);
            AddInstructionToken(tknList, "jle", EnumInstructions.jle);
            AddInstructionToken(tknList, "jl", EnumInstructions.jl);
            AddInstructionToken(tknList, "je", EnumInstructions.je);
            AddInstructionToken(tknList, "jne", EnumInstructions.jne);
            AddInstructionToken(tknList, "jge", EnumInstructions.jge);
            AddInstructionToken(tknList, "jg", EnumInstructions.jg);
            AddInstructionToken(tknList, "irmovq", EnumInstructions.irmov);
            AddInstructionToken(tknList, "rrmovq", EnumInstructions.rrmov);
            AddInstructionToken(tknList, "mrmovq", EnumInstructions.mrmov);
            AddInstructionToken(tknList, "rmmovq", EnumInstructions.rmmov);

            //-----Registers
            AddRegisterToken(tknList, "%rax", EnumRegisters.rax);
            AddRegisterToken(tknList, "%rbx", EnumRegisters.rbx);
            AddRegisterToken(tknList, "%rcx", EnumRegisters.rcx);
            AddRegisterToken(tknList, "%rdx", EnumRegisters.rdx);
            AddRegisterToken(tknList, "%rsp", EnumRegisters.rsp);
            AddRegisterToken(tknList, "%rbp", EnumRegisters.rbp);
            AddRegisterToken(tknList, "%rsi", EnumRegisters.rsi);
            AddRegisterToken(tknList, "%rdi", EnumRegisters.rdi);
            AddRegisterToken(tknList, "%r8", EnumRegisters.r8);
            AddRegisterToken(tknList, "%r9", EnumRegisters.r9);
            AddRegisterToken(tknList, "%r10", EnumRegisters.r10);
            AddRegisterToken(tknList, "%r11", EnumRegisters.r11);
            AddRegisterToken(tknList, "%r12", EnumRegisters.r12);
            AddRegisterToken(tknList, "%r13", EnumRegisters.r13);
            AddRegisterToken(tknList, "%r14", EnumRegisters.r14);

            //-----Address Register
            AddAddressRegisterToken(tknList, "(%rax)", EnumRegisters.rax);
            AddAddressRegisterToken(tknList, "(%rbx)", EnumRegisters.rbx);
            AddAddressRegisterToken(tknList, "(%rcx)", EnumRegisters.rcx);
            AddAddressRegisterToken(tknList, "(%rdx)", EnumRegisters.rdx);
            AddAddressRegisterToken(tknList, "(%rsp)", EnumRegisters.rsp);
            AddAddressRegisterToken(tknList, "(%rbp)", EnumRegisters.rbp);
            AddAddressRegisterToken(tknList, "(%rsi)", EnumRegisters.rsi);
            AddAddressRegisterToken(tknList, "(%rdi)", EnumRegisters.rdi);
            AddAddressRegisterToken(tknList, "(%r8)", EnumRegisters.r8);
            AddAddressRegisterToken(tknList, "(%r9)", EnumRegisters.r9);
            AddAddressRegisterToken(tknList, "(%r10)", EnumRegisters.r10);
            AddAddressRegisterToken(tknList, "(%r11)", EnumRegisters.r11);
            AddAddressRegisterToken(tknList, "(%r12)", EnumRegisters.r12);
            AddAddressRegisterToken(tknList, "(%r13)", EnumRegisters.r13);
            AddAddressRegisterToken(tknList, "(%r14)", EnumRegisters.r14);
        }

        public bool IsKeyword(string val, ref Token tkn)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i].Text == val)
                {
                    tkn = keys[i].DeepCopy();
                    return true;
                }
            }
            return false;
        }

        public bool IsKeyword(string val)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i].Text == val)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
