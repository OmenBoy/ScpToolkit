﻿using System;
using System.ComponentModel;

namespace ScpControl 
{
    public partial class BthDs4 : BthDevice 
    {
        protected Boolean m_DisableLightBar = false, m_Flash = false;
        protected Byte    m_Brightness = Global.Brightness;

        protected static Int32 R = 9, G = 10, B = 11;  // Led Offsets

        protected Byte[] m_Report = 
        {
             0x52, 0x11, 
             0xB0, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF,
             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
             0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
        };

        protected Byte[][] m_InitReport = new Byte[][]
        {
            new Byte[] { 0x07, 0x00, 0x01, 0x02, 0x9B, 0x02, 0x90, 0x36, 0x06, 0x51, 0x35, 0x98, 0x09, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x00, 0x09, 0x00, 0x01, 0x35, 0x03, 0x19, 0x10, 0x00, 0x09, 0x00, 0x04, 0x35, 0x0D, 0x35, 0x06, 0x19, 0x01, 0x00, 0x09, 0x00, 0x01, 0x35, 0x03, 0x19, 0x00, 0x01, 0x09, 0x00, 0x05, 0x35, 0x03, 0x19, 0x10, 0x02, 0x09, 0x00, 0x06, 0x35, 0x09, 0x09, 0x65, 0x6E, 0x09, 0x00, 0x6A, 0x09, 0x01, 0x00, 0x09, 0x01, 0x00, 0x25, 0x12, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65, 0x20, 0x44, 0x69, 0x73, 0x63, 0x6F, 0x76, 0x65, 0x72, 0x79, 0x00, 0x09, 0x01, 0x01, 0x25, 0x25, 0x50, 0x75, 0x62, 0x6C, 0x69, 0x73, 0x68, 0x65, 0x73, 0x20, 0x73, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65, 0x73, 0x20, 0x74, 0x6F, 0x20, 0x72, 0x65, 0x6D, 0x6F, 0x74, 0x65, 0x20, 0x64, 0x65, 0x76, 0x69, 0x63, 0x65, 0x73, 0x00, 0x09, 0x01, 0x02, 0x25, 0x0A, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x00, 0x09, 0x02, 0x00, 0x35, 0x03, 0x09, 0x01, 0x00, 0x09, 0x02, 0x01, 0x0A, 0x00, 0x00, 0x00, 0x0D, 0x35, 0x95, 0x09, 0x00, 0x00, 0x0A, 0x00, 0x01, 0x00, 0x00, 0x09, 0x00, 0x01, 0x35, 0x03, 0x19, 0x12, 0x00, 0x09, 0x00, 0x04, 0x35, 0x0D, 0x35, 0x06, 0x19, 0x01, 0x00, 0x09, 0x00, 0x01, 0x35, 0x03, 0x19, 0x00, 0x01, 0x09, 0x00, 0x05, 0x35, 0x03, 0x19, 0x10, 0x02, 0x09, 0x00, 0x06, 0x35, 0x09, 0x09, 0x65, 0x6E, 0x09, 0x00, 0x6A, 0x09, 0x01, 0x00, 0x09, 0x01, 0x00, 0x25, 0x18, 0x44, 0x65, 0x76, 0x69, 0x63, 0x65, 0x20, 0x49, 0x44, 0x20, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65, 0x20, 0x52, 0x65, 0x63, 0x6F, 0x72, 0x64, 0x09, 0x01, 0x01, 0x25, 0x18, 0x44, 0x65, 0x76, 0x69, 0x63, 0x65, 0x20, 0x49, 0x44, 0x20, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65, 0x20, 0x52, 0x65, 0x63, 0x6F, 0x72, 0x64, 0x09, 0x02, 0x00, 0x09, 0x01, 0x03, 0x09, 0x02, 0x01, 0x09, 0x00, 0x06, 0x09, 0x02, 0x02, 0x09, 0x00, 0x01, 0x09, 0x02, 0x03, 0x09, 0x08, 0x00, 0x09, 0x02, 0x04, 0x28, 0x01, 0x09, 0x02, 0x05, 0x09, 0x00, 0x01, 0x35, 0x9D, 0x09, 0x00, 0x00, 0x0A, 0x00, 0x01, 0x00, 0x01, 0x09, 0x00, 0x01, 0x35, 0x03, 0x19, 0x11, 0x15, 0x09, 0x00, 0x04, 0x35, 0x1B, 0x35, 0x06, 0x19, 0x01, 0x00, 0x09, 0x00, 0x0F, 0x35, 0x11, 0x19, 0x00, 0x0F, 0x09, 0x01, 0x00, 0x35, 0x09, 0x09, 0x08, 0x00, 0x09, 0x86, 0xDD, 0x09, 0x08, 0x06, 0x09, 0x00, 0x05, 0x35, 0x03, 0x19, 0x10, 0x02, 0x09, 0x00, 0x06, 0x35, 0x09, 0x09, 0x65, 0x6E, 0x09, 0x00, 0x6A, 0x09, 0x01, 0x00, 0x09, 0x00, 0x09, 0x35, 0x08, 0x35, 0x06, 0x19, 0x11, 0x15, 0x09, 0x01, 0x00, 0x09, 0x01, 0x00, 0x25, 0x1D, 0x50, 0x65, 0x72, 0x73, 0x6F, 0x6E, 0x61, 0x6C, 0x20, 0x41, 0x64, 0x20, 0x48, 0x6F, 0x63, 0x20, 0x55, 0x73, 0x65, 0x72, 0x20, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65, 0x00, 0x09, 0x01, 0x01, 0x25, 0x1D, 0x50, 0x65, 0x72, 0x73, 0x6F, 0x6E, 0x61, 0x6C, 0x20, 0x41, 0x64, 0x20, 0x48, 0x6F, 0x63, 0x20, 0x55, 0x73, 0x65, 0x72, 0x20, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65, 0x00, 0x09, 0x03, 0x0A, 0x09, 0x00, 0x00, 0x35, 0x5A, 0x09, 0x00, 0x00, 0x0A, 0x00, 0x01, 0x00, 0x02, 0x09, 0x00, 0x01, 0x35, 0x03, 0x19, 0x11, 0x0A, 0x09, 0x00, 0x04, 0x35, 0x10, 0x35, 0x06, 0x19, 0x01, 0x00, 0x09, 0x00, 0x19, 0x35, 0x06, 0x19, 0x00, 0x19, 0x09, 0x01, 0x00, 0x09, 0x00, 0x05, 0x35, 0x03, 0x19, 0x10, 0x02, 0x09, 0x00, 0x06, 0x35, 0x09, 0x09, 0x65, 0x6E, 0x09, 0x00, 0x6A, 0x09, 0x01, 0x00, 0x09, 0x00, 0x09, 0x35, 0x08, 0x35, 0x06, 0x19, 0x11, 0x0D, 0x09, 0x01, 0x02, 0x09, 0x01, 0x00, 0x25, 0x0D, 0x41, 0x75, 0x64, 0x69, 0x6F, 0x20, 0x53, 0x6F, 0x75, 0x72, 0x63, 0x65, 0x00, 0x35, 0x40, 0x09, 0x00, 0x00, 0x0A, 0x00, 0x01, 0x00, 0x03, 0x09, 0x00, 0x01, 0x35, 0x03, 0x19, 0x11, 0x0C, 0x09, 0x00, 0x04, 0x35, 0x10, 0x35, 0x06, 0x19, 0x01, 0x00, 0x09, 0x00, 0x17, 0x35, 0x06, 0x19, 0x00, 0x17, 0x09, 0x01, 0x02, 0x09, 0x00, 0x05, 0x35, 0x03, 0x19, 0x10, 0x02, 0x09, 0x00, 0x09, 0x35, 0x08, 0x35, 0x06, 0x19, 0x11, 0x0E, 0x09, 0x01, 0x03, 0x09, 0x03, 0x11, 0x09, 0x00, 0x01, 0x35, 0x73, 0x09, 0x00, 0x00, 0x0A, 0x00, 0x01, 0x00, 0x05, 0x09, 0x00, 0x01, 0x35, 0x03, 0x19, 0x11, 0x05, 0x09, 0x00, 0x04, 0x35, 0x11, 0x35, 0x03, 0x19, 0x01, 0x00, 0x35, 0x05, 0x19, 0x08, 0xA0, 0x8B, 0x95, 0x08, 0x80, 0xFA, 0xFF, 0xFF, },
            new Byte[] { 0x07, 0x00, 0x02, 0x02, 0x9B, 0x02, 0x90, 0x00, 0x03, 0x08, 0x01, 0x35, 0x03, 0x19, 0x00, 0x08, 0x09, 0x00, 0x05, 0x35, 0x03, 0x19, 0x10, 0x02, 0x09, 0x00, 0x06, 0x35, 0x09, 0x09, 0x65, 0x6E, 0x09, 0x00, 0x6A, 0x09, 0x01, 0x00, 0x09, 0x00, 0x09, 0x35, 0x08, 0x35, 0x06, 0x19, 0x11, 0x05, 0x09, 0x01, 0x02, 0x09, 0x01, 0x00, 0x25, 0x12, 0x50, 0x49, 0x4D, 0x20, 0x49, 0x74, 0x65, 0x6D, 0x20, 0x54, 0x72, 0x61, 0x6E, 0x73, 0x66, 0x65, 0x72, 0x00, 0x09, 0x02, 0x00, 0x09, 0xD6, 0xE1, 0x09, 0x03, 0x03, 0x35, 0x08, 0x08, 0x01, 0x08, 0x02, 0x08, 0x04, 0x08, 0xFF, 0x35, 0x62, 0x09, 0x00, 0x00, 0x0A, 0x00, 0x01, 0x00, 0x06, 0x09, 0x00, 0x01, 0x35, 0x03, 0x19, 0x11, 0x06, 0x09, 0x00, 0x04, 0x35, 0x11, 0x35, 0x03, 0x19, 0x01, 0x00, 0x35, 0x05, 0x19, 0x00, 0x03, 0x08, 0x02, 0x35, 0x03, 0x19, 0x00, 0x08, 0x09, 0x00, 0x05, 0x35, 0x03, 0x19, 0x10, 0x02, 0x09, 0x00, 0x06, 0x35, 0x09, 0x09, 0x65, 0x6E, 0x09, 0x00, 0x6A, 0x09, 0x01, 0x00, 0x09, 0x00, 0x09, 0x35, 0x08, 0x35, 0x06, 0x19, 0x11, 0x06, 0x09, 0x01, 0x02, 0x09, 0x01, 0x00, 0x25, 0x0E, 0x46, 0x69, 0x6C, 0x65, 0x20, 0x54, 0x72, 0x61, 0x6E, 0x73, 0x66, 0x65, 0x72, 0x00, 0x09, 0x02, 0x00, 0x09, 0xD6, 0xE3, 0x35, 0x46, 0x09, 0x00, 0x00, 0x0A, 0x00, 0x01, 0x00, 0x07, 0x09, 0x00, 0x01, 0x35, 0x03, 0x19, 0x11, 0x0E, 0x09, 0x00, 0x04, 0x35, 0x10, 0x35, 0x06, 0x19, 0x01, 0x00, 0x09, 0x00, 0x17, 0x35, 0x06, 0x19, 0x00, 0x17, 0x09, 0x01, 0x03, 0x09, 0x00, 0x05, 0x35, 0x03, 0x19, 0x10, 0x02, 0x09, 0x00, 0x09, 0x35, 0x08, 0x35, 0x06, 0x19, 0x11, 0x0E, 0x09, 0x01, 0x03, 0x09, 0x01, 0x00, 0x25, 0x01, 0x00, 0x09, 0x03, 0x11, 0x09, 0x00, 0x01, 0x35, 0x5A, 0x09, 0x00, 0x00, 0x0A, 0x00, 0x01, 0x00, 0x08, 0x09, 0x00, 0x01, 0x35, 0x03, 0x19, 0x11, 0x0B, 0x09, 0x00, 0x04, 0x35, 0x10, 0x35, 0x06, 0x19, 0x01, 0x00, 0x09, 0x00, 0x19, 0x35, 0x06, 0x19, 0x00, 0x19, 0x09, 0x01, 0x00, 0x09, 0x00, 0x05, 0x35, 0x03, 0x19, 0x10, 0x02, 0x09, 0x00, 0x06, 0x35, 0x09, 0x09, 0x65, 0x6E, 0x09, 0x00, 0x6A, 0x09, 0x01, 0x00, 0x09, 0x00, 0x09, 0x35, 0x08, 0x35, 0x06, 0x19, 0x11, 0x0D, 0x09, 0x01, 0x02, 0x09, 0x01, 0x00, 0x25, 0x0D, 0x53, 0x74, 0x65, 0x72, 0x65, 0x6F, 0x20, 0x41, 0x75, 0x64, 0x69, 0x6F, 0x00, 0x35, 0x6F, 0x09, 0x00, 0x00, 0x0A, 0x00, 0x01, 0x00, 0x09, 0x09, 0x00, 0x01, 0x35, 0x03, 0x19, 0x11, 0x2F, 0x09, 0x00, 0x04, 0x35, 0x11, 0x35, 0x03, 0x19, 0x01, 0x00, 0x35, 0x05, 0x19, 0x00, 0x03, 0x08, 0x03, 0x35, 0x03, 0x19, 0x00, 0x08, 0x09, 0x00, 0x05, 0x35, 0x03, 0x19, 0x10, 0x02, 0x09, 0x00, 0x06, 0x35, 0x09, 0x09, 0x65, 0x6E, 0x09, 0x00, 0x6A, 0x09, 0x01, 0x00, 0x09, 0x00, 0x09, 0x35, 0x08, 0x35, 0x06, 0x19, 0x11, 0x30, 0x09, 0x01, 0x01, 0x09, 0x01, 0x00, 0x25, 0x1C, 0x42, 0x6C, 0x75, 0x65, 0x74, 0x6F, 0x6F, 0x74, 0x68, 0x20, 0x50, 0x68, 0x6F, 0x6E, 0x65, 0x20, 0x42, 0x6F, 0x6F, 0x6B, 0x20, 0x41, 0x63, 0x63, 0x65, 0x73, 0x73, 0x00, 0x09, 0x03, 0x14, 0x08, 0x01, 0x36, 0x01, 0x4B, 0x09, 0x00, 0x00, 0x0A, 0x00, 0x01, 0x00, 0x0A, 0x09, 0x00, 0x01, 0x35, 0x03, 0x19, 0x11, 0x24, 0x09, 0x00, 0x04, 0x35, 0x0D, 0x35, 0x06, 0x19, 0x01, 0x00, 0x09, 0x00, 0x11, 0x35, 0x03, 0x19, 0x00, 0x11, 0x09, 0x00, 0x05, 0x35, 0x03, 0x19, 0x10, 0x02, 0x09, 0x00, 0x06, 0x35, 0x09, 0x09, 0x65, 0x6E, 0x09, 0x00, 0x6A, 0x09, 0x01, 0x00, 0x09, 0x00, 0x09, 0x35, 0x08, 0x35, 0x06, 0x19, 0x11, 0x24, 0x09, 0x01, 0x00, 0x09, 0x00, 0x0D, 0x35, 0x0F, 0x35, 0x0D, 0x35, 0x06, 0x19, 0x01, 0x00, 0x09, 0x00, 0x13, 0x35, 0x03, 0x19, 0x00, 0x11, 0x09, 0x01, 0x00, 0x25, 0x0B, 0x48, 0x49, 0x44, 0x20, 0x44, 0x65, 0x76, 0x69, 0x63, 0x65, 0x00, 0x09, 0x02, 0x00, 0x09, 0x01, 0x40, 0x09, 0x02, 0x01, 0x09, 0x01, 0x11, 0x09, 0x02, 0x02, 0x08, 0x40, 0x09, 0x02, 0x03, 0x08, 0x21, 0x09, 0x02, 0x04, 0x28, 0x00, 0x09, 0x02, 0x05, 0x28, 0x01, 0x09, 0x02, 0x06, 0x35, 0x9B, 0x35, 0x99, 0x08, 0x22, 0x25, 0x95, 0x05, 0x01, 0x09, 0x06, 0xA1, 0x01, 0x05, 0x07, 0x85, 0x01, 0x19, 0xE0, 0x29, 0xE7, 0x15, 0x00, 0x25, 0x01, 0x75, 0x01, 0x95, 0x08, 0x81, 0x02, 0x95, 0x01, 0x75, 0x08, 0x81, 0x01, 0x95, 0x05, 0x75, 0x01, 0x05, 0x08, 0x19, 0x01, 0x29, 0x05, 0x91, 0x02, 0x08, 0xA0, 0x8B, 0x95, 0x08, 0x80, 0xFA, 0xFF, 0xFF, },
            new Byte[] { 0x07, 0x00, 0x03, 0x01, 0x37, 0x01, 0x34, 0x95, 0x01, 0x75, 0x03, 0x91, 0x01, 0x95, 0x06, 0x75, 0x08, 0x15, 0x00, 0x26, 0xA4, 0x00, 0x05, 0x07, 0x19, 0x00, 0x29, 0xA4, 0x81, 0x00, 0xC0, 0x05, 0x01, 0x09, 0x02, 0xA1, 0x01, 0x09, 0x01, 0xA1, 0x00, 0x85, 0x02, 0x05, 0x09, 0x19, 0x01, 0x29, 0x03, 0x15, 0x00, 0x25, 0x01, 0x95, 0x03, 0x75, 0x01, 0x81, 0x02, 0x95, 0x01, 0x75, 0x05, 0x81, 0x03, 0x05, 0x01, 0x09, 0x30, 0x09, 0x31, 0x09, 0x38, 0x15, 0x81, 0x25, 0x7F, 0x75, 0x08, 0x95, 0x03, 0x81, 0x06, 0xC0, 0xC0, 0x05, 0x0C, 0x09, 0x01, 0xA1, 0x01, 0x85, 0x7F, 0x06, 0x00, 0xFF, 0x75, 0x08, 0x95, 0x03, 0x15, 0x00, 0x26, 0xFF, 0x00, 0x1A, 0x00, 0xFC, 0x2A, 0x02, 0xFC, 0xB1, 0x02, 0xC0, 0x09, 0x02, 0x07, 0x35, 0x08, 0x35, 0x06, 0x09, 0x03, 0x09, 0x09, 0x01, 0x00, 0x09, 0x02, 0x08, 0x28, 0x00, 0x09, 0x02, 0x0B, 0x09, 0x01, 0x00, 0x09, 0x02, 0x0D, 0x28, 0x00, 0x09, 0x02, 0x0E, 0x28, 0x00, 0x35, 0x4C, 0x09, 0x00, 0x00, 0x0A, 0x00, 0x01, 0x00, 0x0B, 0x09, 0x00, 0x01, 0x35, 0x06, 0x19, 0x11, 0x12, 0x19, 0x12, 0x03, 0x09, 0x00, 0x04, 0x35, 0x0C, 0x35, 0x03, 0x19, 0x01, 0x00, 0x35, 0x05, 0x19, 0x00, 0x03, 0x08, 0x04, 0x09, 0x00, 0x05, 0x35, 0x03, 0x19, 0x10, 0x02, 0x09, 0x00, 0x09, 0x35, 0x08, 0x35, 0x06, 0x19, 0x11, 0x08, 0x09, 0x01, 0x00, 0x09, 0x01, 0x00, 0x25, 0x0E, 0x41, 0x75, 0x64, 0x69, 0x6F, 0x20, 0x47, 0x61, 0x74, 0x65, 0x77, 0x61, 0x79, 0x00, 0x35, 0x57, 0x09, 0x00, 0x00, 0x0A, 0x00, 0x01, 0x00, 0x0C, 0x09, 0x00, 0x01, 0x35, 0x06, 0x19, 0x11, 0x1F, 0x19, 0x12, 0x03, 0x09, 0x00, 0x04, 0x35, 0x0C, 0x35, 0x03, 0x19, 0x01, 0x00, 0x35, 0x05, 0x19, 0x00, 0x03, 0x08, 0x05, 0x09, 0x00, 0x05, 0x35, 0x03, 0x19, 0x10, 0x02, 0x09, 0x00, 0x09, 0x35, 0x08, 0x35, 0x06, 0x19, 0x11, 0x1E, 0x09, 0x01, 0x06, 0x09, 0x01, 0x00, 0x25, 0x0E, 0x41, 0x75, 0x64, 0x69, 0x6F, 0x20, 0x47, 0x61, 0x74, 0x65, 0x77, 0x61, 0x79, 0x00, 0x09, 0x03, 0x01, 0x08, 0x01, 0x09, 0x03, 0x11, 0x09, 0x00, 0x29, 0x00, },
        };

        public override DsPadId PadId 
        {
            get { return (DsPadId) m_ControllerId; }
            set 
            {
                m_ControllerId = (Byte) value;
                m_ReportArgs.Pad = PadId;

                switch (value)
                {
                    case DsPadId.One:      // Blue
                        m_Report[R] = 0x00; 
                        m_Report[G] = 0x00;
                        m_Report[B] = m_Brightness;
                        break;
                    case DsPadId.Two:      // Green
                        m_Report[R] = 0x00; 
                        m_Report[G] = m_Brightness; 
                        m_Report[B] = 0x00;
                        break;
                    case DsPadId.Three:    // Yellow
                        m_Report[R] = m_Brightness; 
                        m_Report[G] = m_Brightness; 
                        m_Report[B] = 0x00;
                        break;
                    case DsPadId.Four:     // Cyan
                        m_Report[R] = 0x00; 
                        m_Report[G] = m_Brightness; 
                        m_Report[B] = m_Brightness;
                        break;
                    case DsPadId.None:     // Red
                        m_Report[R] = m_Brightness; 
                        m_Report[G] = 0x00; 
                        m_Report[B] = 0x00;
                        break;
                }

                if (Global.DisableLightBar)
                {
                    m_Report[R] = m_Report[G] = m_Report[B] = m_Report[12] = m_Report[13] = 0x00;
                }

                m_Queued = 1;
            }
        }


        public BthDs4() 
        {
            InitializeComponent();
        }

        public BthDs4(IContainer container) 
        {
            container.Add(this);

            InitializeComponent();
        }

        public BthDs4(IBthDevice Device, Byte[] Master, Byte Lsb, Byte Msb) : base(Device, Master, Lsb, Msb) 
        {
        }


        public override Boolean Start() 
        {
            CanStartHid = false;
            m_State = DsState.Connected;

            m_Last = DateTime.Now;
            Rumble(0, 0);

            return base.Start();
        }


        public override void Parse(Byte[] Report) 
        {
            m_Packet++;

            m_ReportArgs.Report[2] = m_BatteryStatus = (Byte)((Report[41] + 2) / 2);

            m_ReportArgs.Report[4] = (Byte)(m_Packet >>  0 & 0xFF);
            m_ReportArgs.Report[5] = (Byte)(m_Packet >>  8 & 0xFF);
            m_ReportArgs.Report[6] = (Byte)(m_Packet >> 16 & 0xFF);
            m_ReportArgs.Report[7] = (Byte)(m_Packet >> 24 & 0xFF);

            Ds4Button Buttons = (Ds4Button)((Report[16] << 0) | (Report[17] << 8) | (Report[18] << 16));
            Boolean   Trigger = false, Active = false;

            //++ Convert HAT to DPAD
            Report[16] &= 0xF0;

            switch ((UInt32) Buttons & 0xF)
            {
                case 0:
                    Report[16] |= (Byte)(Ds4Button.Up);
                    break;
                case 1:
                    Report[16] |= (Byte)(Ds4Button.Up | Ds4Button.Right);
                    break;
                case 2:
                    Report[16] |= (Byte)(Ds4Button.Right);
                    break;
                case 3:
                    Report[16] |= (Byte)(Ds4Button.Right | Ds4Button.Down);
                    break;
                case 4:
                    Report[16] |= (Byte)(Ds4Button.Down);
                    break;
                case 5:
                    Report[16] |= (Byte)(Ds4Button.Down | Ds4Button.Left);
                    break;
                case 6:
                    Report[16] |= (Byte)(Ds4Button.Left);
                    break;
                case 7:
                    Report[16] |= (Byte)(Ds4Button.Left | Ds4Button.Up);
                    break;
            }
            //--

            // Quick Disconnect
            if ((Buttons & Ds4Button.L1) == Ds4Button.L1
             && (Buttons & Ds4Button.R1) == Ds4Button.R1
             && (Buttons & Ds4Button.PS) == Ds4Button.PS
            )
            {
                Trigger = true; Report[18] ^= 0x1;
            }

            for (Int32 Index = 8; Index < 84; Index++)
            {
                m_ReportArgs.Report[Index] = Report[Index + 3];
            }

            m_ReportArgs.Report[8] = Report[9];

            // Buttons
            for (Int32 Index = 16; Index < 18 && !Active; Index++)
            {
                if (Report[Index] != 0) Active = true;
            }

            // Axis
            for (Int32 Index = 12; Index < 16 && !Active; Index++)
            {
                if (Report[Index] < 117 || Report[Index] > 137) Active = true;
            }

            // Triggers
            for (Int32 Index = 19; Index < 21 && !Active; Index++)
            {
                if (Report[Index] != 0) Active = true;
            }

            if (Active)
            {
                m_IsIdle = false;
            }
            else if (!m_IsIdle)
            {
                m_IsIdle = true; m_Idle = DateTime.Now;
            }

            if (Trigger && !m_IsDisconnect)
            {
                m_IsDisconnect = true; m_Disconnect = DateTime.Now;
            }
            else if (!Trigger && m_IsDisconnect)
            {
                m_IsDisconnect = false;
            }

            Publish();
        }

        public override Boolean Rumble(Byte Large, Byte Small) 
        {
            lock (this)
            {
                if (Global.DisableRumble)
                {
                    m_Report[7] = 0;
                    m_Report[8] = 0;
                }
                else
                {
                    m_Report[7] = (Byte)(Small);
                    m_Report[8] = (Byte)(Large);
                }

                if (!m_Blocked)
                {
                    m_Last = DateTime.Now; m_Blocked = true;
                    m_Device.HID_Command(HCI_Handle.Bytes, Get_SCID(L2CAP.PSM.HID_Command), m_Report);
                }
                else
                {
                    m_Queued = 1;
                }
           }

            return true;
        }

        public override Boolean InitReport(Byte[] Report) 
        {
            Boolean retVal = false;

            if (m_Init < m_InitReport.Length)
            {
                m_Device.HID_Command(HCI_Handle.Bytes, Get_SCID(L2CAP.PSM.HID_Service), m_InitReport[m_Init++]);
            }
            else if (m_Init == m_InitReport.Length)
            {
                m_Init++; retVal = true;
            }

            return retVal;
        }


        protected override void Process(DateTime Now) 
        {
            lock (this)
            {
                if (m_State == DsState.Connected)
                {
                    if (!Global.DisableLightBar)
                    {
                        if (Battery < DsBattery.Medium)
                        {
                            if (!m_Flash)
                            {
                                m_Report[12] = m_Report[13] = 0x40;

                                m_Flash = true;
                                m_Queued = 1;
                            }
                        }
                        else
                        {
                            if (m_Flash)
                            {
                                m_Report[12] = m_Report[13] = 0x00;

                                m_Flash = false;
                                m_Queued = 1;
                            }
                        }
                    }

                    if (Global.Brightness != m_Brightness)
                    {
                        m_Brightness = Global.Brightness;
                        PadId = PadId;
                    }

                    if (Global.DisableLightBar != m_DisableLightBar)
                    {
                        m_DisableLightBar = Global.DisableLightBar;
                        PadId = PadId;
                    }

                    if ((Now - m_Last).TotalMilliseconds >= 500)
                    {
                        if (m_Report[7] > 0x00 || m_Report[8] > 0x00)
                        {
                            m_Queued = 1;
                        }
                    }

                    if (!m_Blocked && m_Queued > 0)
                    {
                        m_Last = Now; m_Blocked = true; m_Queued--;

                        m_Device.HID_Command(HCI_Handle.Bytes, Get_SCID(L2CAP.PSM.HID_Command), m_Report);
                    }
                }
            }
        }
    }
}
