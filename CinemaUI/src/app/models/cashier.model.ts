import { Guid } from "guid-typescript";

export interface Cashier
{
    id: Guid;
    login: string;
    password: string;
}