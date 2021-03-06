﻿using System;
using BinaryRecords;
using Autobus.Delegates;
using Autobus.Abstractions;

namespace Autobus.Serialization.BinaryRecords
{
    public class BinaryRecordsSerializationProvider : ISerializationProvider
    {
        private BinarySerializer _serializer;

        public BinaryRecordsSerializationProvider(BinarySerializer serializer) =>_serializer = serializer;

        public BinaryRecordsSerializationProvider() => _serializer = BinarySerializerBuilder.BuildDefault();

        public T Deserialize<T>(ReadOnlyMemory<byte> data) => _serializer.Deserialize<T>(data.Span);

        public void Serialize<TMessage, TState>(TMessage message, TState state, OnSerializedDelegate<TState> onSerialized) =>
            _serializer.Serialize(message, (state, onSerialized), (data, state) => state.onSerialized(data, state.state));
    }
}
