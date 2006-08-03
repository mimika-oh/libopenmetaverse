/*
 * Copyright (c) 2006, Second Life Reverse Engineering Team
 * All rights reserved.
 *
 * - Redistribution and use in source and binary forms, with or without 
 *   modification, are permitted provided that the following conditions are met:
 *
 * - Redistributions of source code must retain the above copyright notice, this
 *   list of conditions and the following disclaimer.
 * - Neither the name of the Second Life Reverse Engineering Team nor the names 
 *   of its contributors may be used to endorse or promote products derived from
 *   this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
 * POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Collections;

namespace libsecondlife.Packets
{
	public class Parcel
	{
		public static Packet ParcelInfoRequest(ProtocolManager protocol, LLUUID parcelID, 
			LLUUID agentID, LLUUID sessionID)
		{
			Hashtable blocks = new Hashtable();
			Hashtable fields = new Hashtable();

			fields["ParcelID"] = parcelID;
			blocks[fields] = "Data";
			fields = new Hashtable();
			fields["AgentID"] = agentID;
			fields["SessionID"] = sessionID;
			blocks[fields] = "AgentData";

			return PacketBuilder.BuildPacket("ParcelInfoRequest", protocol, blocks, 
				Helpers.MSG_RELIABLE + Helpers.MSG_ZEROCODED);
		}

		public static Packet ParcelBuy(ProtocolManager protocol, int localID, bool groupOwned, 
			LLUUID groupID, bool final, LLUUID agentID, LLUUID sessionID)
		{
			Hashtable blocks = new Hashtable();
			Hashtable fields = new Hashtable();

			fields["LocalID"] = localID;
			fields["IsGroupOwned"] = groupOwned;
			fields["GroupID"] = groupID;
			fields["Final"] = final;
			blocks[fields] = "Data";

			fields = new Hashtable();
			fields["AgentID"] = agentID;
			fields["SessionID"] = sessionID;
			blocks[fields] = "AgentData";

			return PacketBuilder.BuildPacket("ParcelBuy", protocol, blocks, Helpers.MSG_RELIABLE);
		}

		public static Packet ParcelDeedToGroup(ProtocolManager protocol, int localID, LLUUID groupID, 
			LLUUID agentID, LLUUID sessionID)
		{
			Hashtable blocks = new Hashtable();
			Hashtable fields = new Hashtable();

			fields["LocalID"] = localID;
			fields["GroupID"] = groupID;
			blocks[fields] = "Data";

			fields = new Hashtable();
			fields["AgentID"] = agentID;
			fields["SessionID"] = sessionID;
			blocks[fields] = "AgentData";

			return PacketBuilder.BuildPacket("ParcelDeedToGroup", protocol, blocks, Helpers.MSG_RELIABLE);
		}

		public static Packet ParcelReclaim(ProtocolManager protocol, int localID,
			LLUUID agentID, LLUUID sessionID)
		{
			Hashtable blocks = new Hashtable();
			Hashtable fields = new Hashtable();

			fields["LocalID"] = localID;
			blocks[fields] = "Data";

			fields = new Hashtable();
			fields["AgentID"] = agentID;
			fields["SessionID"] = sessionID;
			blocks[fields] = "AgentData";

			return PacketBuilder.BuildPacket("ParcelReclaim", protocol, blocks, Helpers.MSG_RELIABLE);
		}

		public static Packet ParcelRelease(ProtocolManager protocol, int localID,
			LLUUID agentID, LLUUID sessionID)
		{
			Hashtable blocks = new Hashtable();
			Hashtable fields = new Hashtable();

			fields["LocalID"] = localID;
			blocks[fields] = "Data";

			fields = new Hashtable();
			fields["AgentID"] = agentID;
			fields["SessionID"] = sessionID;
			blocks[fields] = "AgentData";

			return PacketBuilder.BuildPacket("ParcelRelease", protocol, blocks, Helpers.MSG_RELIABLE);
		}

		public static Packet ParcelPropertiesRequest(ProtocolManager protocol, LLUUID agentID, int sequenceID,
			float west, float south, float east, float north, bool snapSelection) 
		{
			Hashtable blocks = new Hashtable();
			Hashtable fields = new Hashtable();

			fields["AgentID"] = agentID;
			fields["SequenceID"] = sequenceID;
			fields["West"] = west;
			fields["South"] = south;
			fields["East"] = east;
			fields["North"] = north;
			fields["SnapSelection"] = snapSelection;

			blocks[fields] = "ParcelData";	
			return PacketBuilder.BuildPacket("ParcelPropertiesRequest", protocol, blocks, Helpers.MSG_RELIABLE);
		}

		public static Packet ParcelPropertiesRequestByID(ProtocolManager protocol, LLUUID agentID, int sequenceID,
			int localID) 
		{
			Hashtable blocks = new Hashtable();
			Hashtable fields = new Hashtable();

			fields["AgentID"] = agentID;
			fields["SequenceID"] = sequenceID;
			fields["LocalID"] = localID;

			blocks[fields] = "ParcelData";	
			return PacketBuilder.BuildPacket("ParcelPropertiesRequestByID", protocol, blocks, Helpers.MSG_RELIABLE);
		}
	}
}
