import { reducer, CatsState } from '../../ClientApp/store/Cats';

describe('Reducer', () => {
    it('should return the initial state', () => {
        expect(reducer(null, {})).toEqual({ cats: [] })
    })

    it('should handle REQUEST_CATS', () => {
        expect(reducer({ cats: [] }, { type: 'REQUEST_CATS' })).toEqual({ cats: [] })
    })

    it('should handle RECEIVE_CATS', () => {
        expect(reducer({ cats: [] }, { type: 'RECEIVE_CATS' })).toEqual({ undefined })
    })
})


//test('adds 1 + 2 to equal 3', () => {
//    expect(1 + 2).toBe(3);
//});