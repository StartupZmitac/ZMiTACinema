import { Guid } from "guid-typescript";

export interface Price
{
    id: Guid,
    type: string,
    cost: number
}