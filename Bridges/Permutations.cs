using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges
{
  class Permutations
  {
    private List<int> m_permutation = null;
    private int m_size = 0;

    public Permutations( int size )
    {
      m_size = 0;
      m_permutation = new List<int>( size );
      for ( int i = 0; i < size; i++ )
      {
        m_permutation [i] = i;
      }
    }

    public void MoveNext()
    {
      int i = m_size - 1;
      while ( m_permutation [i - 1] >= m_permutation [i] )
        i = i - 1;

      int j = m_size;
      while ( m_permutation [j - 1] <= m_permutation [i - 1] )
        j = j - 1;

      Swap( i - 1, j - 1 );    // swap values at positions (i-1) and (j-1)

      i++;
      j = m_size;

      while ( i < j )
      {
        Swap( i - 1, j - 1 );
        i++;
        j--;
      }
    }

    private void Swap( int a, int b )
    {
      int temp = m_permutation [a];
      m_permutation [a] = m_permutation [b];
      m_permutation [b] = temp;
    }
  }
}
