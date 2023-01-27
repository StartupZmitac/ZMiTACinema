import { Guid } from "guid-typescript";
import { Room } from "./room.model";

export interface Ticket
{
    id: string|null;
    transaction_id: string;
    isChecked: boolean;
    isPaid: boolean;
    seat: string;
    type: string;
    screening_ID: string
}