export interface Ticket
{
    id: string|null;
    transaction_id: string;
    isChecked: boolean;
    isPaid: boolean;
    seat: string;
    type: string;
    screening_ID: string;
    price_ID:string
}